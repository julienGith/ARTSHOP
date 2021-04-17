using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.LocalisationLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep5Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep6Model : PageModel
    {
        LocalisationLogic localisation = new LocalisationLogic();
        [BindProperty]
        public Step6 step6 { get; set; }
        public class Step6
        {
            public int locaId { get; set; }
            public int Btqid { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Rue")]
            public string Rue { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Numéro")]
            public string Num { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "ville")]
            public string Ville { get; set; }
            [Required]
            [StringLength(5,MinimumLength = 5)]
            [Display(Name = "CodePostal")]
            public string Codepostal { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Pays")]
            public string Pays { get; set; }
            [Required]
            public string Departement { get; set; }
        }

        public async Task<IActionResult> OnPost()
        {
            Step5 step5 = new Step5();
            step5 = HttpContext.Session.Get<Step5>("step5");

            var result = await localisation.AddBoutiqueLocalisation(step5.boutiqueId,step6.Rue,step6.Num,step6.Ville,step6.Codepostal,"France",step6.Departement);
            step6.locaId = result.Localisationid;
            HttpContext.Session.Set<Step6>("step6", step6);

            return RedirectToPage("/boutique/CreateBoutiqueStep7");
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step6>("step6", step6);
            return Redirect("/boutique/CreateBoutiqueStep5");
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<Step6>("step6") != null)
            {
                step6 = HttpContext.Session.Get<Step6>("step6");
                if (step6.locaId>0)
                {
                    await localisation.DeleteLocalisation(step6.locaId);

                }
            }
            return Page();
        }
    }
}
