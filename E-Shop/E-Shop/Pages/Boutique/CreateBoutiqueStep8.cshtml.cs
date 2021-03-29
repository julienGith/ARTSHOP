using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.MediaLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep5Model;

namespace E_Shop.Pages.Boutique
{

    public class CreateBoutiqueStep8Model : PageModel
    {
        MediaLogic media = new MediaLogic();

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
