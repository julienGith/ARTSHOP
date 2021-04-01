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

        public SelectList Options { get; set; }

        public class Input
        {
            public string CatNom { get; set; }
            public int CatId { get; set; }

        }
        public async Task<IActionResult> OnPostAdd()
        {
            await categorieLogic.AddCategorie(input.CatNom, int.Parse(Options.DataValueField));
            return Page();
        }
        public async void OnGet()
        {

            var categories = await categorieLogic.GetAllCategories();

            Options = new SelectList(categories, nameof(input.CatId), nameof(input.CatNom));
        }
    }
}
