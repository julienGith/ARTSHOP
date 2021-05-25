using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Stripe;

namespace E_Shop.Pages.MaCommande
{
    public class PaiementModel : PageModel
    {
        BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
        public PaiementModel(IConfiguration config)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
        }
        public Cart cart = new Cart();

        public string PublicKey { get; }
        public void OnPostCreate()
        {
            //cart = HttpContext.Session.Get<Models.Cart>("Cart");
            //foreach (var btq in cart.Btqs)
            //{
            //    string StripeAcct = boutiqueLogic.GetBoutiqueStripeAcct(btq.id);

            //    var paymentIntents = new PaymentIntentService();
            //    var paymentIntent = paymentIntents.Create(new PaymentIntentCreateOptions
            //    {
            //        Amount = (long)btq.ItemsTotalprice * 100,
            //        Currency = "eur",
            //        ApplicationFeeAmount = 123,
            //        TransferData = new PaymentIntentTransferDataOptions
            //        {
            //            Destination = StripeAcct,
            //        },

            //    });
                
            //}
            //return new JsonResult(new { clientSecret = paymentIntent.ClientSecret });
        }

        public IActionResult OnGet()
        {
            return Page();
        }
    }
}
