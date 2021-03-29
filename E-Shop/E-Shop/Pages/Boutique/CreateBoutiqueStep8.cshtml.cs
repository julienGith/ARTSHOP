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
            public int? Btqid { get; set; }
            public string Lien { get; set; }
            public string Description { get; set; }
            public bool Image { get; set; }
            public bool Video { get; set; }
            public string Html { get; set; }

            [Display(Name = "Télécharger une image de vous")]
            public string FileNameImg1 { get; set; }
            [Display(Name = "Télécharger une image inspirant l'esprit de votre boutique")]
            public string FileNameImg2 { get; set; }
            [Display(Name = "Indiquer le lien vers votre vidéo de présentation de votre boutique")]
            public string VideoLink { get; set; }


        }
        public async Task<IActionResult> OnPostImg1(IFormFile photo1)
        {
            if (photo1 == null || photo1.Length == 0)
            {
                return BadRequest();
            }

            using (var memoryStream = new MemoryStream())
            {
                await photo1.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    var newimg = Imager.Resize(img, 125, 125, false);
                    var newname = Guid.NewGuid().ToString() + ".jpeg";
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname);
                    Imager.SaveJpeg(path, newimg);
                    step8.Lien = "/images/" + newname;
                }
            }


            return Page();
        }
        public async Task<IActionResult> OnPostImg2(IFormFile photo2)
        {

            var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", photo2.FileName);
            var stream = new FileStream(path, FileMode.Create);
            await photo2.CopyToAsync(stream);
            step8.Lien = photo2.FileName;
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            Step5 step5 = new Step5();
            step5 = HttpContext.Session.Get<Step5>("step5");

            HttpContext.Session.Set<Step8>("step8", step8);

            await media.AddBoutiqueMedias(step5.boutiqueId,step8.Lien,step8.Image,step8.Video,step8.Description);
            return RedirectToPage("/boutique/CreateBoutiqueStep9");
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step8>("step8", step8);
            return Redirect("/boutique/CreateBoutiqueStep7");
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get<Step8>("step8") != null)
            {
                step8 = HttpContext.Session.Get<Step8>("step8");
            }
        }
    }
}
