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
