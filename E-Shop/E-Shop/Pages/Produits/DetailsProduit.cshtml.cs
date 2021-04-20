using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.LocalisationLogic;
using E_Shop.Logic.MediaLogic;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Produits
{
    public class DetailsProduitModel : PageModel
    {
        private ProduitLogic ProduitLogic = new ProduitLogic();
        private BoutiqueLogic BoutiqueLogic = new BoutiqueLogic();
        private MediaLogic mediaLogic = new MediaLogic();
        private LocalisationLogic LocalisationLogic = new LocalisationLogic();
        
        public Produit produit = new Produit();
        public Entities.Boutique boutique = new Entities.Boutique();
        public List<Medium> mediasBtq = new List<Medium>();
        public List<Medium> mediasProd = new List<Medium>();
        public Localisation localisation = new Localisation();
        public string imgVignette { get; set; }
        public string imgProd { get; set; }

        [FromQuery(Name = "prodId")]
        public int prodId { get; set; }
        public async Task<IActionResult> OnGet()
        {
            produit = await ProduitLogic.GetProduitById(prodId);
            boutique = await BoutiqueLogic.GetBoutiqueById(produit.Btqid);
            mediasBtq = await mediaLogic.GetMediasBoutique(produit.Btqid);
            foreach (var item in mediasBtq)
            {
                if (item.Description == "vignette")
                {
                    imgVignette = item.Lien;
                }
            }
            mediasProd = await mediaLogic.GetMediasByProdId(prodId);
            foreach (var item in mediasProd)
            {
                if (item.Description==produit.PNom)
                {
                    imgProd = item.Lien;
                }
            }
            localisation = await LocalisationLogic.GetLocalisationBoutique(produit.Btqid);

            return Page();
        }
    }
}
