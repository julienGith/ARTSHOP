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
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
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
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set<Step4>("step4", step4);

                CreateBoutiqueStep1Model.Step1 step1 = new CreateBoutiqueStep1Model.Step1();
                CreateBoutiqueStep2Model.Step2 step2 = new CreateBoutiqueStep2Model.Step2();
                CreateBoutiqueStep3Model.Step3 step3 = new CreateBoutiqueStep3Model.Step3();

                step1 = HttpContext.Session.Get<Step1>("step1");
                step2 = HttpContext.Session.Get<Step2>("step2");
                step3 = HttpContext.Session.Get<Step3>("step3");
                var result = await politiqueLogic.AddPolitique(step4.Echange, step4.Remboursement, step4.Pltqdescription);
                await boutiqueLogic.AddBoutique(step1.UserId, result.Politiqueid, step1.BDescriptionC, step1.BDescriptionL, step1.Raisonsociale, step2.Siret, step2.Siren, step2.Btqtel,
                    step2.Codenaf, step3.Codebanque, step3.Codeguichet, step3.Numcompte, step3.Clerib, step3.Domiciliation, step3.Iban, step3.Bic, step3.Titulaire, step2.Btqtmail,
                    null, step2.Ca, step2.Nbsalarie, step2.Siteweb, step2.Statutjuridique, step2.Btqseo);
                return Redirect("/boutique/CreateBoutiqueStep5");
            }
            return Page();
        }
        public IActionResult OnPostBack()
        {
            step4.Pltqdescription = step4.Pltqdescription.ToHtml();
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
