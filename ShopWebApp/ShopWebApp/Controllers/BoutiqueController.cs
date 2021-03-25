using Microsoft.AspNetCore.Mvc;
using ShopWebApp.Entities;
using ShopWebApp.Logic.BoutiqueLogic;
using ShopWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShopWebApp.Controllers
{
    public class BoutiqueController : Controller
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();

        [HttpGet]
        public IActionResult Etape0()
        {
            return View("BoutiqueEtape0");
        }

        [HttpGet]
        public IActionResult CreateBoutique()
        {
            return View();
        }
    }
}
