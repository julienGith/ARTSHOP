using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Produits
{
    public class ListeProduitsModel : PageModel
    {
        private ProduitLogic produitLogic = new ProduitLogic();
        public List<Produit> listProduits = new List<Produit>();
        [FromQuery(Name = "catId")]
        public int catId { get; set; }
        public async Task<IActionResult> OnGet()
        {
            listProduits = await produitLogic.GetProduitsByCatId(catId);
            return Page();
        }
    }
}
