using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Logic;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace E_Shop.Pages.Produits
{
    public class ListeProduitsModel : PageModel
    {
        private ProduitLogic produitLogic = new ProduitLogic();
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
        public List<Produit> listProduits = new List<Produit>();
        public PaginatedList<Produit> listProduitsByBtq { get; set; }
        public List<Entities.Boutique> listBtq { get; set; }
        public bool byProd { get; set; }

        [FromQuery(Name = "catId")]
        public int catId { get; set; }
        [BindProperty]
        public int id { get; set; }

        public async Task<IActionResult> OnPostByProd(int catId, int? pageIndex)
        {
            id = catId;
            byProd = true;
            listProduits = await produitLogic.GetProduitsByCatId(catId, pageIndex);
            return Page();
        }
        public async Task<IActionResult> OnGet(int? pageIndex)
        {
            byProd = false;
            listBtq = await boutiqueLogic.GetBoutiquesByCatId(catId, pageIndex);
            return Page();
        }
        public async Task<JsonResult> OnPostProdList(string query)
        {
            listProduits = await produitLogic.GetListProduitByQuery(query);
            var noms = listProduits.Select(p => p.PNom).ToList();
            var response = listProduits.Select(p => new { p.PNom, p.Prodid, p.Media.FirstOrDefault(m => m.Description == "min").Lien }).ToList();
            return new JsonResult(response);
        }
    }
}
