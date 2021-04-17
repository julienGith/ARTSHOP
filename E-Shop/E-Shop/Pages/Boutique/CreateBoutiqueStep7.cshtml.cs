using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.LocalisationLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep5Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep7Model : PageModel
    {
        LocalisationLogic localisation = new LocalisationLogic();


        [BindProperty]
        public Step7 step7 { get; set; }
        public class Step7
        {

            public int locaId { get; set; }
            public int Btqid { get; set; }
            [StringLength(255)]
            [Display(Name = "Rue")]
            public string Rue { get; set; }
            [StringLength(255)]
            [Display(Name = "Numéro")]
            public string Num { get; set; }
            [StringLength(255)]
            [Display(Name = "ville")]
            public string Ville { get; set; }
            [StringLength(5, MinimumLength = 5)]
            [Display(Name = "CodePostal")]
            public string Codepostal { get; set; }
            [StringLength(255)]
            [Display(Name = "Pays")]
            public string Pays { get; set; }
            [Display(Name = "Nom du point relais")]
            [StringLength(255)]
            public string PrNom { get; set; }
            public string Departement { get; set; }

        }
        public async Task<IActionResult> OnPostNext()
        {
            if (step7.Codepostal !=null || step7.PrNom != null || step7.Num != null)
            {
                Step5 step5 = new Step5();
                step5 = HttpContext.Session.Get<Step5>("step5");

                var result = await localisation.AddRelaisLocalisation(step5.boutiqueId, step7.Rue, step7.Num, step7.Ville,
                    step7.Codepostal, "France", step7.PrNom, step7.Departement);
                step7.locaId = result.Localisationid;
                HttpContext.Session.Set<Step7>("step7", step7);

                return RedirectToPage("/boutique/CreateBoutiqueStep8");
            }
            return RedirectToPage("/boutique/CreateBoutiqueStep8");
        }

        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step7>("step7", step7);
            return Redirect("/boutique/CreateBoutiqueStep6");
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<Step7>("step7") != null)
            {
                step7 = HttpContext.Session.Get<Step7>("step7");
                if (step7.locaId>0)
                {
                    await localisation.DeleteLocalisation(step7.locaId);
                }
            }
            return Page();
        }
    }
}
