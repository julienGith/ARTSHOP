using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Boutiques
{
    public class DetailsBoutiqueModel : PageModel
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
        private CategorieLogic categorieLogic = new CategorieLogic();
        public Entities.Boutique boutique { get; set; }
        public List<Entities.Categorie> categories = new List<Entities.Categorie>();
        [FromQuery(Name ="btqid")]
        public int btqid { get; set; }

        public async Task<IActionResult> OnGet()
        {
            categories = await categorieLogic.GetCategoriesByBtqId(btqid);
            boutique = await boutiqueLogic.GetBoutiqueById(btqid);
            return Page();
        }
    }
}
