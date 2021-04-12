using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Logic.FormatLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class EditFormatProduitModel : PageModel
    {
        private FormatLogic formatLogic = new FormatLogic();
        public void OnGet()
        {

        }
    }
}
