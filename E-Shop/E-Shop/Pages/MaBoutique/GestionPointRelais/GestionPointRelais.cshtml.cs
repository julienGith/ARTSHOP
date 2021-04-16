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

        public IActionResult OnPostCr()
        {
            HttpContext.Session.Set<int>("Pr", 0);

            return Redirect("/MaBoutique/GestionPointRelais/EditPointRelais");
        }
        public IActionResult OnPostUp()
        {
            HttpContext.Session.Set<int>("Pr", localisationId);
            return Redirect("/MaBoutique/GestionPointRelais/EditPointRelais");
        }
        public async Task<IActionResult> OnPostDel()
        {
            HttpContext.Session.Set<int>("Pr", 0);
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                btqId = HttpContext.Session.Get<int>("btqId"); 
            }
            await LocalisationLogic.DeletePointRelaisBtq(localisationId,btqId);
            await GetPointRelais();

            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            await GetPointRelais();
            return Page();
        }

        private async Task GetPointRelais()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                btqId = HttpContext.Session.Get<int>("btqId");
                pointRelais = await LocalisationLogic.GetPointRelaisByBoutiqueId(btqId);
            }
        }
    }
}
