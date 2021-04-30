using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
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
        public async Task<IActionResult> OnPostAddToCart(string prodId,string idformat, string quantity)
        {
            Format format = new Format();
            format = await formatLogic.GetFormatById(int.Parse(idformat));
            Produit produit = new Produit();
            produit = await ProduitLogic.GetProduitById(int.Parse(prodId));
            List<Medium> medias = new List<Medium>();
            medias = await mediaLogic.GetMediasByProdId(int.Parse(prodId));
            string lien = medias.Where(m => m.Description == "min").Select(m => m.Lien).FirstOrDefault();
            Item item = new Item
            {
                format = format,
                produit = produit,
                lien = lien,
                quantity = int.Parse(quantity)
            };
            Cart cart = new Cart();

            if (HttpContext.Session.Get<Cart>("Cart")==null)
            {
                cart.items.Add(item);
            }
            else
            {
                bool present = false;
                cart = HttpContext.Session.Get<Cart>("Cart");
                foreach (var i in cart.items)
                {
                    if (i.produit.Prodid==item.produit.Prodid && i.format.Formatid==item.format.Formatid)
                    {
                        present = true;
                        i.quantity++;
                    }
                }
                if (present==false)
                {
                    cart.items.Add(item);
                }
            }
            HttpContext.Session.Set<Cart>("Cart", cart);
            return new JsonResult(cart.items.Count);

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
