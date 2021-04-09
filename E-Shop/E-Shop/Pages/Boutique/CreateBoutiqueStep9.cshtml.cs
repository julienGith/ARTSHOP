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
    public class CreateBoutiqueStep9Model : PageModel
    {
        MediaLogic media = new MediaLogic();
        private IWebHostEnvironment _webHostEnvironment;

        public CreateBoutiqueStep9Model(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public Step9 step9 { get; set; }

        public class Step9
        {
            public int MediaId { get; set; }
            public string Lien { get; set; }
            public string LienComplet { get; set; }
            public int Btqid { get; set; }
            public string Description { get; set; }
            public bool Image { get; set; }
            public bool Video { get; set; }
            public string Html { get; set; }
            [Display(Name = "Télécharger une image inspirant l'esprit de votre boutique")]
            public string FileNameImg { get; set; }
            [Display(Name = "Indiquer le lien vers votre vidéo de présentation de votre boutique")]
            public string VideoLink { get; set; }
        }
        public async Task<IActionResult> OnPostImg(IFormFile photo)
        {
            if (HttpContext.Session.Get<string>("LienComplet9") != null)
            {
                var lien = HttpContext.Session.Get<string>("LienComplet9");
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
                    var newimg = Imager.Resize(img, 835, 300, false);
                    var newname = Guid.NewGuid().ToString() + ".jpeg";
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname);
                    Imager.SaveJpeg(path, newimg);
                    step9.Lien = "/images/" + newname;
                    var LienComplet = Path.Combine(Directory.GetCurrentDirectory(),
                        _webHostEnvironment.WebRootPath, "images\\", newname);
                    HttpContext.Session.Set<string>("LienComplet9", LienComplet);
                    HttpContext.Session.Set<string>("step9lien", step9.Lien.ToString());

                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostNext()
        {
            Step5 step5 = new Step5();
            step5 = HttpContext.Session.Get<Step5>("step5");
            step9.Image = true;
            step9.Description = "pano";
            step9.Lien = HttpContext.Session.Get<string>("step9lien");
            step9.LienComplet = HttpContext.Session.Get<string>("LienComplet9");

            var result = await media.AddBoutiqueMedias(step5.boutiqueId, step9.Lien, step9.Image, step9.Video, step9.Description, step9.LienComplet);
            step9.MediaId = result.Mediaid;
            HttpContext.Session.Set<Step9>("step9", step9);

            return RedirectToPage("/boutique/CreateBoutiqueStep10");
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step9>("step9", step9);
            return Redirect("/boutique/CreateBoutiqueStep8");
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<Step9>("step9") != null)
            {
                step9 = HttpContext.Session.Get<Step9>("step9");
                if (step9.MediaId>0)
                {
                    await media.DeleteMedia(step9.MediaId);
                }
            }
            return Page();
        }
    }
}
