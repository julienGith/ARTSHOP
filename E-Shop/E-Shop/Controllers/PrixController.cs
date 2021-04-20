using E_Shop.Entities;
using E_Shop.Logic.FormatLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Controllers
{
    public class PrixController : Controller
    {
        private FormatLogic formatLogic = new FormatLogic();
        [HttpPost]
        public async Task<JsonResult> GetPrixByFormatId([FromQuery]int formatId)
        {
            Format format = new Format();
            format = await formatLogic.GetFormatById(formatId);

            return Json(new { Data = format.Prix.ToString()});
        }
        [HttpGet]
        public ActionResult test()
        {
            return Json("HELO BitchL");
        }
    }
}
