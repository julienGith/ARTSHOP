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
        [BindProperty]
        public int prodId { get; set; }

        public IActionResult OnPostCrProduit()
        {
            return Redirect("/MaBoutique/Produit/ChoixCategorieStep1");
        }
        public IActionResult OnPostUpProduit()
        {
            HttpContext.Session.Set<int>("prodIdUp", prodId);
            return Redirect("/MaBoutique/Produit/Description");
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
