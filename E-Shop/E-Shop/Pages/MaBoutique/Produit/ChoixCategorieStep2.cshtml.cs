using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using E_Shop.Extensions;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class ChoixCategorieStep2Model : PageModel
    {
        private CategorieLogic categorieLogic = new CategorieLogic();
        public List<SelectListItem> CatEnfants { get; set; }
        [BindProperty]
        public int Categorieid { get; set; }

        public IActionResult OnPost()
        {
            HttpContext.Session.Set<int>("catEnfantId1", Categorieid);
            return RedirectToPage("/MaBoutique/Produit/ChoixCategorieStep3");

        }
        public async Task OnGet()
        {
            var parentId = HttpContext.Session.Get<int>("catParentId");
            CatEnfants = await categorieLogic.GetSelectListItemCategoriesEnfants(parentId);

        }
    }
}
