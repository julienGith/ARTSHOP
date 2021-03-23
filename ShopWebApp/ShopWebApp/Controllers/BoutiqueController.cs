using Microsoft.AspNetCore.Mvc;
using ShopWebApp.Entities;
using ShopWebApp.Logic.BoutiqueLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopWebApp.Controllers
{
    public class BoutiqueController : Controller
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();

        [HttpPost]
        public async Task<Boolean> AddBoutique()
        {
            if (ModelState.IsValid)
            {
                Boutique boutique = new Boutique
                {

                }; 

            }
            return await boutiqueLogic.AddBoutique();
        }
        [HttpGet]
        public IActionResult CreateBoutique()
        {
            return View();
        }
    }
}
