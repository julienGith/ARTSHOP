using E_Shop.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.ViewComponents
{
    public class Cart : ViewComponent
    {
        
        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            Models.Cart cart = new Models.Cart();
            if (HttpContext.Session.Get<Models.Cart>("Cart")!=null)
            {
                
                cart = HttpContext.Session.Get<Models.Cart>("Cart");
                return View("Cart", cart);
            }
            return View("Cart", cart);
            
        }
    }
}
