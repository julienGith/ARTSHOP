using System;
using System.Collections.Generic;
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
using static E_Shop.Pages.Boutique.CreateBoutiqueStep10Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep2Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep5Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep6Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep8Model;
using static E_Shop.Pages.Boutique.CreateBoutiqueStep9Model;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep11Model : PageModel
    {
        private readonly UserManager<Partenaire> _userManager;
        private BoutiqueLogic _boutiqueLogic = new BoutiqueLogic();

        public CreateBoutiqueStep11Model(UserManager<Partenaire> userManager, IConfiguration config)
        {
            SecretKey = config["Stripe:SecretKey"].ToString();
            _userManager = userManager;
        }
        public Step11 step11 { get; set; }
        public string SecretKey { get; }

        public class Step11
        {
            public string lienImg1 { get; set; }
            public string lienImg2 { get; set; }
            public string lienVideo { get; set; }
            public string BtqDescription { get; set; }
            public string BtqNom { get; set; }
            public string Dept { get; set; }
            public string RaisonSociale { get; set; }
            public string Siret { get; set; }
            public string dateCreation { get; set; }


        }
        public async Task<IActionResult> OnPostStripe()
        {

            if (HttpContext.Session.Get<Step5>("step5")!=null)
            {
                Step5 step5 = new Step5();
                step5 = HttpContext.Session.Get<Step5>("step5");
                var result = CreateStripeAccountLink(step5.StripeAcct);
                return Redirect(result);
            }
            else
            {
                Entities.Boutique boutique = new Entities.Boutique();
                List<Entities.Boutique> boutiques = new List<Entities.Boutique>();
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                boutiques = await _boutiqueLogic.GetPartenaireBoutiques(user.Id);
                boutique = boutiques.FirstOrDefault();
                var result = CreateStripeAccountLink(boutique.StripeAcct);
                return Redirect(result);
            }

        }

        private string CreateStripeAccountLink(string StripeAcct)
        {
            StripeConfiguration.ApiKey = SecretKey;
            var LinkOptions = new AccountLinkCreateOptions
            {
                Account = StripeAcct,
                RefreshUrl = "https://localhost:44318/Boutique/CreateBoutiqueStep11",
                ReturnUrl = "https://localhost:44318/MaBoutique/TableauDeBord",
                Type = "account_onboarding",
            };
            var LinkService = new AccountLinkService();
            var accountLink = LinkService.Create(LinkOptions);
            return accountLink.Url;
        }

        public async Task<IActionResult> OnGet()
        {
            Step2 step2 = new Step2();
            Step5 step5 = new Step5();
            Step6 step6 = new Step6();
            Step8 step8 = new Step8();
            Step9 step9 = new Step9();
            Step10 step10 = new Step10();

            if (HttpContext.Session.Get<Step2>("step2") != null)
            {
                step2 = HttpContext.Session.Get<Step2>("step2");
                step5 = HttpContext.Session.Get<Step5>("step5");
                step6 = HttpContext.Session.Get<Step6>("step6");
                step8 = HttpContext.Session.Get<Step8>("step8");
                step9 = HttpContext.Session.Get<Step9>("step9");
                
                step11 = new Step11
                {
                    BtqDescription = step5.BDescriptionL,
                    BtqNom = step2.Nom,
                    lienImg1 = step8.Lien,
                    lienImg2 = step9.Lien,
                    Dept = step6.Departement,
                    RaisonSociale = step2.Raisonsociale,
                    Siret = step2.Siret,
                    dateCreation = step5.dateCreation                    
                };
                if (HttpContext.Session.Get<Step10>("step10")!=null)
                {
                    step10 = HttpContext.Session.Get<Step10>("step10");
                    step11.lienVideo = step10.Lien;
                }
            }
            if (HttpContext.Session.Get<Step2>("step2") == null)
            {
                Entities.Boutique boutique = new Entities.Boutique();
                List<Entities.Boutique> boutiques = new List<Entities.Boutique>();
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                boutiques = await _boutiqueLogic.GetPartenaireBoutiques(user.Id);
                boutique = boutiques.FirstOrDefault();
                step11.lienImg1 = boutique.Media.Where(m => m.Description == "vignette").Select(m=>m.Lien).ToString();
                step11.lienImg2 = boutique.Media.Where(m => m.Description == "pano").Select(m => m.Lien).ToString();
                step6.Departement = boutique.Localisations.Where(l=>l.PrNom==null).Select(l=>l.Departement).ToString();
                step11 = new Step11
                {
                    BtqDescription = boutique.BDescriptionL,
                    BtqNom = boutique.BtqNom,
                    lienImg1 = step11.lienImg1,
                    lienImg2 = step11.lienImg2,
                    Dept = step6.Departement,
                    RaisonSociale = boutique.Raisonsociale,
                    Siret = boutique.Siret,
                    dateCreation = boutique.DateCreation
                };
                if (boutique.Media.Where(m => m.Video == true).Select(m => m.Lien).ToString() != null)
                {
                    step10.Lien = boutique.Media.Where(m => m.Video == true).Select(m => m.Lien).ToString();
                    step11.lienVideo = step10.Lien;
                }
            }
            return Page();
        }
    }
}
