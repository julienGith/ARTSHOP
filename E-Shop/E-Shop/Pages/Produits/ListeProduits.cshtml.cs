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
        public List<Produit> Produits = new List<Produit>();

        public PaginatedList<Produit> listProduits { get; set; }
        public PaginatedList<Entities.Boutique> listBtq { get; set; }
        public bool byProd { get; set; }
        [BindProperty]
        [FromQuery(Name = "catId")]
        public int catId { get; set; }
        [BindProperty]
        public int id { get; set; }
        [BindProperty]
        [FromQuery(Name = "pageIndex")]
        public int? pageIndex { get; set; }
        [BindProperty]
        public int? page { get; set; }
        public int totalpage { get; set; }


        public async Task<IActionResult> OnPostByProd()
        {
            //problème avec les param from query qui ne se bind pas.. 
            pageIndex = page;
            catId = id;
            byProd = true;
            listProduits = await produitLogic.GetProduitsByCatId(id, page);
            return Page();
        }
        public async Task<IActionResult> OnGet(int catId, int? pageIndex)
        {
            if (pageIndex!=null)
            {
                page = pageIndex;
                id = catId;
            }
            if (pageIndex> totalpage)
            {
                page = 1;
            }
            byProd = false;
            listBtq = await boutiqueLogic.GetBoutiquesByCatId(id, page);
            totalpage = listBtq.TotalPages;
            return Page();
        }
        public async Task<JsonResult> OnPostProdList(string query)
        {
            Produits = await produitLogic.GetListProduitByQuery(query);
            var noms = listProduits.Select(p => p.PNom).ToList();
            var response = listProduits.Select(p => new { p.PNom, p.Prodid, p.Media.FirstOrDefault(m => m.Description == "min").Lien }).ToList();
            return new JsonResult(response);
        }
    }
}
