using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.FormatLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class EditFormatProduitModel : PageModel
    {
        private FormatLogic FormatLogic = new FormatLogic();
        public int formatId { get; set; }
        [BindProperty]
        public Format format { get; set; }

        private FormatLogic formatLogic = new FormatLogic();
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("formatId")>0)
            {
                formatId = HttpContext.Session.Get<int>("formatId");
                format = await FormatLogic.GetFormatById(formatId);
            }
            return Page();
        }
    }
}
