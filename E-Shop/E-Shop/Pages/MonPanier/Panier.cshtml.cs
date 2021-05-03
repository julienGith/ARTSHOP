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
        [BindProperty]
        public int prodId { get; set; }
        [BindProperty]
        public int quantity { get; set; }
        public IActionResult OnPostDeleteProd()
        {
            cart = HttpContext.Session.Get<Models.Cart>("Cart");
            foreach (var btq in cart.Btqs)
            {
                foreach (var i in btq.items)
                {
                    if (i.produit.Prodid == prodId)
                    {
                        btq.items.Remove(i);
                    }
                }
            }
            HttpContext.Session.Set<Models.Cart>("Cart", cart);
            return Page();
        }
        public IActionResult OnPostChangeQuantity()
        {
            cart = HttpContext.Session.Get<Models.Cart>("Cart");
            foreach (var btq in cart.Btqs)
            {
                foreach (var i in btq.items)
                {
                    if (i.produit.Prodid==prodId)
                    {
                        i.quantity = quantity;
                    }
                }
            }
            HttpContext.Session.Set<Models.Cart>("Cart", cart);
            return Page();
        }
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
