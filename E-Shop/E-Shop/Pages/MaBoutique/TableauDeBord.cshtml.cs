using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique
{
    public class TableauDeBordModel : PageModel
    {
        private CategorieLogic categorieLogic = new CategorieLogic();

        public void OnGet()
        {

        }
    }
}
