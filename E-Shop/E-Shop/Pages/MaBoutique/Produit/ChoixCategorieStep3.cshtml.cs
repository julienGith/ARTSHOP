using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using E_Shop.Extensions;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class ChoixCategorieStep3Model : PageModel
    {
        private CategorieLogic categorieLogic = new CategorieLogic();
        public List<SelectListItem> CatEnfants2 { get; set; }
        [BindProperty]
        public int Categorieid { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                HttpContext.Session.Set<int>("Cat", Categorieid);
                return RedirectToPage("/MaBoutique/Produit/Description");
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            var parentId = HttpContext.Session.Get<int>("catEnfantId1");
            CatEnfants2 = await categorieLogic.GetSelectListItemCategoriesEnfants(parentId);
            if (CatEnfants2.Count==0)
            {
                return RedirectToPage("/MaBoutique/Produit/Description");

            }
            return Page();

        }
    }
}
