using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Logic;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.ProduitLogic;
using E_Shop.Models;
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
        public PaginatedList<Entities.Boutique> listBtq1 { get; set; }
        [BindProperty]
        public bool? byProd { get; set; }
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
        [BindProperty]
        public string sortOrder { get; set; }
        public Geo geo { get; set; }
        [BindProperty]
        public string region { get; set; }
        [BindProperty]
        public string departement { get; set; }
        public Geo.Region regionChoisie { get; set; }
        public Geo.Departement departementChoisi { get; set; }


        public async Task<IActionResult> OnPostByProd()
        {
            if (byProd==true)
            {
                page = 1;
            }
            catId = id;
            geo = await produitLogic.GetGeoProduitsCountByCatID(catId);
            if (region!=null)
            {
                regionChoisie = geo.Regions.FirstOrDefault(r => r.nom == region);
                departementChoisi = regionChoisie.departements.FirstOrDefault(d => d.nom == departement);
            }
            listProduits = await produitLogic.GetProduitsByCatId(id, page, sortOrder, departement, regionChoisie);
            return Page();
        }
        public async Task<IActionResult> OnPostByBout()
        {
            catId = id;
            if (byProd==false)
            {
                page = 1;
            }
            geo = await boutiqueLogic.GetBoutiqueCountByGeo(catId);
            if (region != null)
            {
                regionChoisie = geo.Regions.FirstOrDefault(r => r.nom == region);
                departementChoisi = regionChoisie.departements.FirstOrDefault(d => d.nom == departement);
            }
            listBtq = await boutiqueLogic.GetBoutiquesByCatId(id, page, departement, regionChoisie);
            totalpage = listBtq.TotalPages;

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
            geo = await boutiqueLogic.GetBoutiqueCountByGeo(catId);
            byProd = false;
            listBtq = await boutiqueLogic.GetBoutiquesByCatId(id, page, departement, regionChoisie);
            totalpage = listBtq.TotalPages;
            return Page();
        }
        public async Task<IActionResult> OnPostGeo(int catId, int? pageIndex)
        {
            if (pageIndex != null)
            {
                page = pageIndex;
                id = catId;
            }
            if (pageIndex > totalpage)
            {
                page = 1;
            }
            if (byProd == false)
            {
                geo = await boutiqueLogic.GetBoutiqueCountByGeo(catId);
                if (region != null)
                {
                    regionChoisie = geo.Regions.FirstOrDefault(r => r.nom == region);
                    departementChoisi = regionChoisie.departements.FirstOrDefault(d => d.nom == departement);
                }
                listBtq = await boutiqueLogic.GetBoutiquesByCatId(id, page, departement, regionChoisie);
            }
            if (byProd == true)
            {
                geo = await produitLogic.GetGeoProduitsCountByCatID(catId);
                if (region != null)
                {
                    regionChoisie = geo.Regions.FirstOrDefault(r => r.nom == region);
                    departementChoisi = regionChoisie.departements.FirstOrDefault(d => d.nom == departement);
                }
                listProduits = await produitLogic.GetProduitsByCatId(id, page, sortOrder, departement, regionChoisie);
            }
            return Page();
        }
        public async Task<JsonResult> OnPostProdList(string query)
        {
            Produits = await produitLogic.GetListProduitByQuery(query);
            var noms = Produits.Select(p => p.PNom).ToList();
            var response = Produits.Select(p => new { p.PNom, p.Prodid, p.Media.FirstOrDefault(m => m.Description == "min").Lien }).ToList();
            return new JsonResult(response);
        }
    }
}
