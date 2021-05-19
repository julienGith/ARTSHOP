using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using Stripe;
using Microsoft.Extensions.Configuration;

namespace E_Shop.Pages.MaBoutique
{
    public class TableauDeBordModel : PageModel
    {
        private CategorieLogic _categorieLogic = new CategorieLogic();
        private BoutiqueLogic _boutiqueLogic = new BoutiqueLogic();
        private readonly UserManager<Partenaire> _userManager;
        public TableauDeBordModel(UserManager<Partenaire> userManager, IConfiguration config)
        {
            SecretKey = config["Stripe:SecretKey"].ToString();

            _userManager = userManager;
        }
        public string SecretKey { get; }

        public List<Entities.Boutique> Boutiques = new List<Entities.Boutique>();
        public IActionResult OnPostPdr()
        {
            return Redirect("/MaBoutique/GestionPointRelais/GestionPointRelais");
        }
        public IActionResult OnPostLivraisonType()
        {
            return Redirect("/MaBoutique/LivraisonType/GestionLivraisonType");
        }
        public IActionResult OnPostGestionProd()
        {
            return Redirect("/MaBoutique/Produit/GestionProduit");
        }
        public IActionResult OnPostGestionBout()
        {
            return Redirect("/MaBoutique/GestionBoutique/GestionBoutique");
        }
        public async Task<IActionResult> OnPostStripe()
        {
            var result = await CreateStripeAccount();
            return Redirect(result);

        }
        public void OnPostStripeDelete()
        {
            StripeConfiguration.ApiKey = SecretKey;
            var service = new AccountService();
            service.Delete("acct_1Is1Kz4I5DY3p1lw");
            service.Delete("acct_1Is1KPQTc3c3OAGS");
        }
        private async Task<string> CreateStripeAccount()
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

            var LinkOptions = new AccountLinkCreateOptions
            {
                Account = result.Id,
                RefreshUrl = "https://example.com/reauth",
                ReturnUrl = "https://localhost:44318/MaBoutique/TableauDeBord",
                Type = "account_onboarding",
                
                
            };
            var LinkService = new AccountLinkService();
            var accountLink = LinkService.Create(LinkOptions);
            return accountLink.Url;
        }
        public async Task OnGetAsync()
        {
            var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            HttpContext.Session.Set<int>("user", user.Id);
            Boutiques = await _boutiqueLogic.GetPartenaireBoutiques(user.Id);
            var btqId = Boutiques.FirstOrDefault().Btqid;
            HttpContext.Session.Set<int>("btqId", btqId);
        }
    }
}
