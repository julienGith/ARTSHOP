using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.MediaLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.GestionBoutique
{
    public class MediasModel : PageModel
    {
        private MediaLogic mediaLogic = new MediaLogic();
        List<Medium> medias = new List<Medium>();

        public int boutiqueId { get; set; }

        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                boutiqueId = HttpContext.Session.Get<int>("btqId");
                medias = await mediaLogic.GetMediasBoutique(boutiqueId);
            }
            return Page();
        }
    }
}
