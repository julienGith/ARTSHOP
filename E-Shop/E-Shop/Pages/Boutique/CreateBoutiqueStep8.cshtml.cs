using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic;
using E_Shop.Logic.MediaLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep5Model;

namespace E_Shop.Pages.Boutique
{

    public class CreateBoutiqueStep8Model : PageModel
    {
        MediaLogic media = new MediaLogic();
        private IWebHostEnvironment _webHostEnvironment;

        public CreateBoutiqueStep8Model(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Step8 step8 { get; set; }


        public class Step8
        {
            public int MediaId { get; set; }
            public string Lien { get; set; }
            public string FileName { get; set; }
            public int Btqid { get; set; }
            public string Description { get; set; }
            public bool Image { get; set; }
            public bool Video { get; set; }
            public string Html { get; set; }
            [Display(Name = "Télécharger une image de vous")]
            public string FileNameImg { get; set; }

        }

        public async Task<IActionResult> OnPostImg(IFormFile photo)
        {
            if (HttpContext.Session.Get<string>("LienComplet8") != null)
            {

                var lien = HttpContext.Session.Get<string>("LienComplet8");
                if (System.IO.File.Exists(lien))
                {
                    System.IO.File.Delete(lien);
                }
            }
            if (photo == null || photo.Length == 0)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await photo.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    var newimg = Imager.Resize(img, 125, 125, false);
                    var newname = Guid.NewGuid().ToString() + ".jpeg";
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname);
                    Imager.SaveJpeg(path, newimg);
                    step8.Lien = "/images/" + newname;
                    var LienComplet = Path.Combine(Directory.GetCurrentDirectory(),
                        _webHostEnvironment.WebRootPath, "images\\", newname);

                    HttpContext.Session.Set<string>("LienComplet8", LienComplet);
                    HttpContext.Session.Set<string>("step8lien", step8.Lien.ToString());
                    HttpContext.Session.Set<string>("fileName8", newname);


                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostNext()
        {
            Step5 step5 = new Step5();
            step5 = HttpContext.Session.Get<Step5>("step5");
            step8.Image = true;
            step8.Description = "vignette";
            step8.Lien= HttpContext.Session.Get<string>("step8lien");
            step8.FileName = HttpContext.Session.Get<string>("fileName8");
            var result = await media.AddBoutiqueMedias(step5.boutiqueId, step8.Lien, step8.Image, step8.Video, step8.Description,step8.FileName);
            step8.MediaId = result.Mediaid;
            HttpContext.Session.Set<Step8>("step8", step8);

            return RedirectToPage("/boutique/CreateBoutiqueStep9");
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step8>("step8", step8);
            return Redirect("/boutique/CreateBoutiqueStep7");
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<Step8>("step8") != null)
            {
                step8 = HttpContext.Session.Get<Step8>("step8");
                if (step8.MediaId>0)
                {
                    await media.DeleteMedia(step8.MediaId);
                }
            }
            return Page();
        }
    }
}
