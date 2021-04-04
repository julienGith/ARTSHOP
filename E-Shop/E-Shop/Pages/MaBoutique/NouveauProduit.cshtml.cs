using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Logic.CategorieLogic;
using E_Shop.Logic.MediaLogic;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Pages.MaBoutique
{
    public class NouveauProduitModel : PageModel
    {
        private CategorieLogic categorieLogic = new CategorieLogic();
        private ProduitLogic produitLogic = new ProduitLogic();
        private MediaLogic mediaLogic = new MediaLogic();

        public List<SelectListItem> CatParents { get; set; }
        public List<SelectListItem> CatEnfants1 { get; set; }
        public List<SelectListItem> CatEnfants2 { get; set; }


        public void OnGet()
        {

        }
    }
}
