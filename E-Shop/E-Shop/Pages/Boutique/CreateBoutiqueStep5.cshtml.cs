using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep1Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep2Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep3Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep4Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep5Model : PageModel
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();

        [BindProperty]
        public Step5 step5 { get; set; }
        public class Step5
        {
            [Required]
            [StringLength(500)]
            [Display(Name = "Description courte")]
            public string BDescriptionC { get; set; }
            [Required]
            [StringLength(4000)]
            [Display(Name = "Description Longue")]
            public string BDescriptionL { get; set; }

            public int boutiqueId { get; set; }

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                step5.BDescriptionL = step5.BDescriptionL.ToHtml();
                step5.BDescriptionC = step5.BDescriptionC.ToHtml();
                HttpContext.Session.Set<Step5>("step5", step5);

                Step2 step2 = new Step2();
                Step3 step3 = new Step3();
                Step4 step4 = new Step4();


                step2 = HttpContext.Session.Get<Step2>("step2");
                step3 = HttpContext.Session.Get<Step3>("step3");
                step4 = HttpContext.Session.Get<Step4>("step4");
                var result = await boutiqueLogic.AddBoutique(step2.UserId, step4.Politiqueid, step5.BDescriptionC, step5.BDescriptionL, step2.Raisonsociale, step2.Siret, step2.Siren, step2.Btqtel,
                    step2.Codenaf, step3.Codebanque, step3.Codeguichet, step3.Numcompte, step3.Clerib, step3.Domiciliation, step3.Iban, step3.Bic, step3.Titulaire, step2.Btqtmail,
                    null, 0, step2.Nbsalarie, step2.Siteweb, step2.Statutjuridique, step2.Btqseo);
                step5.boutiqueId = result.Btqid;
                return RedirectToPage("/boutique/CreateBoutiqueStep6");
            }
            return Page();

        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<Step5>("step5") != null)
            {
                step5 = HttpContext.Session.Get<Step5>("step5");
                await boutiqueLogic.DeleteBoutique(step5.boutiqueId);
            }
            return Page();
        }

    }
}
