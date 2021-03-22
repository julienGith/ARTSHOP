using Logic.ProduitLogic;
using Microsoft.AspNetCore.Mvc;
using ShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Controllers
{
    public class ProduitController : Controller
    {
        private ProduitLogic produit = new ProduitLogic();
        public IActionResult Index()
        {
            return View();
        }
        //FIRST TEST BRO !
        [Route("all")]
        [HttpGet]
        public async Task<List<ProduitViewModel>> GetAllProduit()
        {
            List<ProduitViewModel> produitViewModels = new List<ProduitViewModel>();
            var produits = await produit.GetAllProduits();
            foreach (var item in produits)
            {
                ProduitViewModel produit = new ProduitViewModel
                {
                    PNom = item.PNom,
                    PDescriptionC=item.PDescriptionC,
                    Prix=item.Prix
                };
                produitViewModels.Add(produit);
            }
            return produitViewModels;
        }
    }
}
