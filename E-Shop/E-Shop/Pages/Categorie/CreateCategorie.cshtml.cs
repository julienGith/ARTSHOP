using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_Shop.Pages.Categorie
{
    public class CreateCategorieModel : PageModel
    {

        private CategorieLogic categorieLogic = new CategorieLogic();


        [BindProperty]
        public Input input { get; set; }

        public List<SelectListItem> Options { get; set; }
        public class Input
        {
            public string Categorienom { get; set; }
            public int Categorieid { get; set; }

        }
        public async Task<IActionResult> OnPostAdd()
        {

            if (input.Categorieid > 0)
            {
                await categorieLogic.AddCategorie(input.Categorienom, input.Categorieid);
            }
            else
            {
                await categorieLogic.AddCategorie(input.Categorienom, null);
                var Categories = await categorieLogic.GetAllCategories();
                ViewData["Categories"] = Categories;

            }
            input.Categorienom = "";
            Options = categorieLogic.GetSelectListItemCategories();
            return Page();
        }
        public void OnGet()
        {
            Options =  categorieLogic.GetSelectListItemCategories();
        }
    }
}
