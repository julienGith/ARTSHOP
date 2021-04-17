using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.FormatLogic;
using E_Shop.Logic.LivraisonTypeLogic;
using E_Shop.Logic.MediaLogic;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class GestionProduitModel : PageModel
    {
        private ProduitLogic produitLogic = new ProduitLogic();
        private LivraisonTypeLogic livraisonTypeLogic = new LivraisonTypeLogic();
        private ProduitLogic ProduitLogic = new ProduitLogic();
        private FormatLogic FormatLogic = new FormatLogic();
        private MediaLogic mediaLogic = new MediaLogic();
        private IWebHostEnvironment _webHostEnvironment;
        public GestionProduitModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        public List<Entities.Produit> produits = new List<Entities.Produit>();
        [BindProperty]
        public int prodId { get; set; }
        public string LienProdImgMini { get; set; }

        public IActionResult OnPostCrProduit()
        {
            return Redirect("/MaBoutique/Produit/ChoixCategorieStep1");
        }
        public IActionResult OnPostUpProduit()
        {
            HttpContext.Session.Set<int>("prodIdUp", prodId);
            return Redirect("/MaBoutique/Produit/Description");
        }
        public async Task<IActionResult> OnPostDelProduit()
        {
            var listLvrTypes = await livraisonTypeLogic.GetLivraisontypeByProdId(prodId);
            foreach (var item in listLvrTypes)
            {
                await livraisonTypeLogic.RemoveLivraisonTypeProduit(item.Lvrtypid);
            }
            var formats = await FormatLogic.GetFormatsByProductId(prodId);
            foreach (var item in formats)
            {
                await FormatLogic.DeleteFormat(item.Formatid);
            }
            var imgProd = await mediaLogic.GetMediasByProdId(prodId);
            foreach (var item in imgProd)
            {
                await mediaLogic.DeleteMedia(item.Mediaid, _webHostEnvironment);
            }
            await produitLogic.DeleteProduit(prodId);
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                var btqId = HttpContext.Session.Get<int>("btqId");
                produits = await produitLogic.GetBoutiqueProduits(btqId);
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                var btqId = HttpContext.Session.Get<int>("btqId");
                produits = await produitLogic.GetBoutiqueProduits(btqId);
            }
            return Page();
        }
    }
}
