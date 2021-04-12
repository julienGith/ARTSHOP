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
    public class GestionFormatProduitModel : PageModel
    {
        private FormatLogic formatLogic = new FormatLogic();
        public List<Format> formats { get; set; }
        public int prodId { get; set; }
        [BindProperty]
        public int formatId { get; set; }

        public async Task<IActionResult> OnPostDel()
        {
            await formatLogic.DeleteFormat(formatId);
            if (HttpContext.Session.Get<int>("prodId") > 0)
            {
                prodId = HttpContext.Session.Get<int>("prodId");
                formats = await formatLogic.GetFormatsByProductId(prodId);
            }
            return Page();
        }
        public IActionResult OnPostUp()
        {
            HttpContext.Session.Set<int>("formatId", formatId);
            return Redirect("/MaBoutique/Produit/EditFormatProduit");
        }
        public IActionResult OnPostCR()
        {
            HttpContext.Session.Set<int>("formatId", 0);
            return Redirect("/MaBoutique/Produit/EditFormatProduit");
        }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("prodId")>0)
            {
                prodId = HttpContext.Session.Get<int>("prodId");
                formats = await formatLogic.GetFormatsByProductId(prodId);
            }
            return Page();
        }
    }
}
