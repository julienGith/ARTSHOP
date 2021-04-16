using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.LocalisationLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.GestionPointRelais
{
    public class GestionPointRelaisModel : PageModel
    {
        private LocalisationLogic LocalisationLogic = new LocalisationLogic();
        public List<Localisation> pointRelais = new List<Localisation>();
        [BindProperty]
        public int localisationId { get; set; }
        public int btqId { get; set; }
        //public async Task<IActionResult> OnPostCr()
        //{

        //}
        public async Task<IActionResult> OnGet()
        {
            GetPointRelais();
            return Page();
        }

        private async void GetPointRelais()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                btqId = HttpContext.Session.Get<int>("btqId");
                pointRelais = await LocalisationLogic.GetPointRelaisByBoutiqueId(btqId);
            }
        }
    }
}
