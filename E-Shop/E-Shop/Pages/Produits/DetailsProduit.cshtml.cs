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
        public async Task<IActionResult> OnPostFormatId()
        {
            Format = await formatLogic.GetFormatById(formatId);
            prix = Format.Prix;

            return Page();
        }
        public ActionResult OnGetTest2()
        {

            return new JsonResult("hello");
        }
        public async Task<ActionResult> OnGetTest(string formatId)
        {
            int formatId2 = int.Parse(formatId);
            Format format = new Format();
            format = await formatLogic.GetFormatById(formatId2);
            return new JsonResult(format.Prix);
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
