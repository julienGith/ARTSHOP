using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Categorie
{
    public class CategorieMenuModel : PageModel
    {
        private CategorieLogic categorieLogic = new CategorieLogic();

        public class catmenu
        {
            public string CategorieNom { get; set; }
            public int CategorieId { get; set; }

        }

        public async Task OnGet()
        {
           await categorieLogic.GetAllCategories();
        }
    }
}
