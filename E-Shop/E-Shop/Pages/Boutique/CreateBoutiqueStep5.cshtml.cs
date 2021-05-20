using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep1Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep2Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep3Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep4Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep5Model : PageModel
    {
        public string SecretKey { get; }
        private readonly UserManager<Partenaire> _userManager;
        public CreateBoutiqueStep5Model(UserManager<Partenaire> userManager, IConfiguration config)
        {
            SecretKey = config["Stripe:SecretKey"].ToString();
            _userManager = userManager;
        }
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
            public string dateCreation { get; set; }
            public int boutiqueId { get; set; }
            public string StripeAcct { get; set; }

        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {

                Step2 step2 = new Step2();
                Step3 step3 = new Step3();
                Step4 step4 = new Step4();
                var SAcct = CreateStripeAcct().ToString();
                step5.StripeAcct = SAcct;

                step2 = HttpContext.Session.Get<Step2>("step2");
                step3 = HttpContext.Session.Get<Step3>("step3");
                step4 = HttpContext.Session.Get<Step4>("step4");
                step5.dateCreation = DateTime.Today.ToString("dd-MM-yyyy");
                var result = await boutiqueLogic.AddBoutique(step2.UserId, step4.Politiqueid, step5.BDescriptionC,
                    step5.BDescriptionL, step2.Raisonsociale,step2.Nom, step2.Siret, step2.Siren, step2.Btqtel,
                    step2.Codenaf, step3.Codebanque, step3.Codeguichet, step3.Numcompte, step3.Clerib, step3.Domiciliation,
                    step3.Iban, step3.Bic, step3.Titulaire, step2.Btqtmail,
                    null, 0, step2.Nbsalarie, null, step2.Statutjuridique, null, step5.dateCreation, step5.StripeAcct);
                step5.boutiqueId = result.Btqid;
                HttpContext.Session.Set<Step5>("step5", step5);

                return RedirectToPage("/boutique/CreateBoutiqueStep6");
            }
            return Page();

        }

        private async Task<string> CreateStripeAcct()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            StripeConfiguration.ApiKey = SecretKey;
            var options = new AccountCreateOptions
            {
                Type = "express",
                Country = "FR",
                Email = user.Email,
                Capabilities = new AccountCapabilitiesOptions
                {
                    CardPayments = new AccountCapabilitiesCardPaymentsOptions
                    {
                        Requested = true,
                    },
                    Transfers = new AccountCapabilitiesTransfersOptions
                    {
                        Requested = true,
                    },
                },
            };
            var service = new AccountService();
            var result = service.Create(options);
            return result.Id;
        }

        public IActionResult OnPostBack()
        {
            HttpContext.Session.Set<Step5>("step5", step5);
            return Redirect("/boutique/CreateBoutiqueStep4");
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<Step5>("step5") != null)
            {
                step5 = HttpContext.Session.Get<Step5>("step5");
                if (step5.boutiqueId>0)
                {
                    await boutiqueLogic.DeleteBoutique(step5.boutiqueId);

                }
            }
            return Page();
        }

    }
}
