using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MonPanier
{
    public class PanierModel : PageModel
    {
        public Cart cart = new Cart();

        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get<Models.Cart>("Cart") != null)
            {
                cart = HttpContext.Session.Get<Models.Cart>("Cart");
            }
            return Page();
        }
    }
}
