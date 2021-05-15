using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace E_Shop.Pages.MaCommande
{
    public class PaiementModel : PageModel
    {
        public PaiementModel(IConfiguration config)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
        }
        public Cart cart = new Cart();

        public string PublicKey { get; }
        public IActionResult OnPostCreate()
        {
            cart = HttpContext.Session.Get<Models.Cart>("Cart");
            var paymentIntents = new PaymentIntentService();
            var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            {
                Amount = (long)cart.prixTotal * 100,
                Currency = "eur",

            });

            return new JsonResult(new { clientSecret = paymentIntent.ClientSecret });
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
