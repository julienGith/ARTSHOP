using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
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
        public List<Produit> listProduitsByBtq = new List<Produit>();
        public List<Entities.Boutique> listBtq = new List<Entities.Boutique>();
        public bool byProd { get; set; }

        [FromQuery(Name = "catId")]
        public int catId { get; set; }
        [BindProperty]
        public int id { get; set; }

        public async Task<IActionResult> OnPostByProd(int catId)
        {
            id = catId;
            byProd = true;
            listProduits = await produitLogic.GetProduitsByCatId(catId);
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            byProd = false;
            listBtq = await boutiqueLogic.GetBoutiquesByCatId(catId);
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
