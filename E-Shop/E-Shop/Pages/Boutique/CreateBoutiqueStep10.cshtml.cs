using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.MediaLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep5Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep10Model : PageModel
    {
        private IWebHostEnvironment _webHostEnvironment;

        public CreateBoutiqueStep10Model(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        MediaLogic media = new MediaLogic();

        [BindProperty]
        public Step10 step10 { get; set; }

        public class Step10
        {
            public int MediaId { get; set; }
            [Display(Name = "Indiquer le lien vers votre vidéo de présentation de votre boutique")]
            public string Lien { get; set; }
            public int Btqid { get; set; }
            public string Description { get; set; }
            public bool Image { get; set; }
            public bool Video { get; set; }
            public string Html { get; set; }
            [Display(Name = "Indiquer le lien vers votre vidéo de présentation de votre boutique")]
            public string VideoLink { get; set; }
        }
        public IActionResult OnPostVid()
        {
            if (step10.Lien!=string.Empty)
            {
                step10.Lien = GetYoutubeId(step10.Lien);
                HttpContext.Session.Set<string>("step10lien", step10.Lien);
            }
            return Page();

        }

        private string GetYoutubeId(string lien)
        {
            string pattern = @"(?:https?:\/\/)?(?:www\.)?(?:(?:(?:youtube.com\/watch\?[^?]*v=|youtu.be\/)([\w\-]+))(?:[^\s?]+)?)";
            string replacement = "https://www.youtube.com/embed/$1";
            var rgx = new Regex(pattern);
            var result = rgx.Replace(lien, replacement);
            return result;
        }

        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step10>("step10", step10);
            return Redirect("/boutique/CreateBoutiqueStep9");
        }
        public async Task<IActionResult> OnPostNext()
        {
            if (HttpContext.Session.Get<string>("step10lien")!=null)
            {
                Step5 step5 = new Step5();
                step5 = HttpContext.Session.Get<Step5>("step5");
                step10.Video = true;
                step10.Description = "boutique";
                step10.Lien = HttpContext.Session.Get<string>("step10lien");
                var result = await media.AddBoutiqueMedias(step5.boutiqueId, step10.Lien, false, step10.Video, step10.Description, null);
                step10.MediaId = result.Mediaid;
                HttpContext.Session.Set<Step10>("step10", step10);
            }
            return RedirectToPage("/boutique/CreateBoutiqueStep11");
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<Step10>("step10") != null)
            {
                step10 = HttpContext.Session.Get<Step10>("step10");
                if (step10.MediaId>0)
                {
                    await media.DeleteMedia(step10.MediaId, _webHostEnvironment);
                }
            }
            return Page();
        }
    }

}
