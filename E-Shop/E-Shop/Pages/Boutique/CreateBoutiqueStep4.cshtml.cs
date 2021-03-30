using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.PolitiqueLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep1Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep2Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep3Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep4Model : PageModel
    {
        private PolitiqueLogic politiqueLogic = new PolitiqueLogic();

        [BindProperty]
        public Step4 step4 { get; set; }
        public class Step4
        {
            [Required]
            [Display(Name = "Echange accepté")]
            public bool Echange { get; set; }
            [Required]
            [Display(Name = "Remboursement accepté")]
            public bool Remboursement { get; set; }
            [Required]
            [Display(Name = "Description de votre politique")]
            public string Pltqdescription { get; set; }

            public int Politiqueid { get; set; }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                step4.Pltqdescription = step4.Pltqdescription;
                var result = await politiqueLogic.AddPolitique(step4.Echange, step4.Remboursement, step4.Pltqdescription);
                step4.Politiqueid = result.Politiqueid;
                HttpContext.Session.Set<Step4>("step4", step4);
                return Redirect("/boutique/CreateBoutiqueStep5");
            }
            return Page();
        }
        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step4>("step4", step4);
            return Redirect("/boutique/CreateBoutiqueStep3");
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get<Step4>("step4") != null)
            {
                step4 = HttpContext.Session.Get<Step4>("step4");
            }
        }
    }
}
