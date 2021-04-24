using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.FormatLogic;
using E_Shop.Logic.LocalisationLogic;
using E_Shop.Logic.MediaLogic;
using E_Shop.Logic.ProduitLogic;
using E_Shop.Models;
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
        private FormatLogic formatLogic = new FormatLogic();

        public List<Format> Formats = new List<Format>();
        public Format Format = new Format();
        public Produit produit = new Produit();
        public Entities.Boutique boutique = new Entities.Boutique();
        public List<Medium> mediasBtq = new List<Medium>();
        public List<Medium> mediasProd = new List<Medium>();
        public Localisation localisation = new Localisation();
        public string imgVignette { get; set; }
        public string imgProd { get; set; }
        [FromQuery(Name = "prodId")]
        public int prodId { get; set; }
        [BindProperty]
        public int formatId { get; set; }
        public decimal? prix { get; set; }


        public async Task<JsonResult> OnPostFormat(string formatId)
        {
            Format format = new Format();
            format = await formatLogic.GetFormatById(int.Parse(formatId));

            return new JsonResult(format.Prix);
        }
        public async Task<JsonResult> OnPostAddToCart(string prodId,string formatId, string quantity)
        {
            Format format = new Format();
            format = await formatLogic.GetFormatById(int.Parse(formatId));
            Produit produit = new Produit();
            produit = await ProduitLogic.GetProduitById(int.Parse(prodId));
            Item item = new Item
            {
                format = format,
                produit = produit,
                quantity = int.Parse(quantity)
            };
            List<Item> items = new List<Item>();
            items.Add(item);
            Cart cart = new Cart
            {
                items = items
            };
            return new JsonResult("hello");
        }

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
            Formats = await formatLogic.GetFormatsByProductId(prodId);
            localisation = await LocalisationLogic.GetLocalisationBoutique(produit.Btqid);

            return Page();
        }

    }
}
