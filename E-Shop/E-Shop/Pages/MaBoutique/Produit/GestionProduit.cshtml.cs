using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class GestionProduitModel : PageModel
    {
        private ProduitLogic produitLogic = new ProduitLogic();
        public List<Entities.Produit> produits = new List<Entities.Produit>();
        public int prodId { get; set; }

        public IActionResult OnPostCrProduit()
        {
            return Redirect("/MaBoutique/Produit/ChoixCategorie");
        }
        public async Task<IActionResult> OnPostUpProduit()
        {
            HttpContext.Session.Set<int>("prodId", prodId);
            return Redirect("/MaBoutique/Produit/");
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                var btqId = HttpContext.Session.Get<int>("btqId");
                produits = await produitLogic.GetBoutiqueProduits(btqId);
            }
            return Page();
        }
    }
}
