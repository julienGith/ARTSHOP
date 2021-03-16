using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.Controllers
{
    public class ProduitController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
