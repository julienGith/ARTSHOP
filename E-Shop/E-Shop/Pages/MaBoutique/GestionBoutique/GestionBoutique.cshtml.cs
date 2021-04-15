using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.BoutiqueLogic;
using E_Shop.Logic.LocalisationLogic;
using E_Shop.Logic.MediaLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.GestionBoutique
{
    public class GestionBoutiqueModel : PageModel
    {
        private BoutiqueLogic boutiqueLogic = new BoutiqueLogic();
        private MediaLogic mediaLogic = new MediaLogic();
        private LocalisationLogic LocalisationLogic = new LocalisationLogic();

        public Entities.Boutique Boutique = new Entities.Boutique();
        public List<Medium> medias = new List<Medium>();
        public Localisation localisation = new Localisation();
        List<RelaisLocB> relaisLocBs = new List<RelaisLocB>();

        public string imgVignette { get; set; }
        public string imgPano { get; set; }
        public string vid { get; set; }



        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId")>0)
            {
                var btqId = HttpContext.Session.Get<int>("btqId");
                Boutique = await boutiqueLogic.GetBoutiqueById(btqId);
                medias = await mediaLogic.GetMediasBoutique(btqId);
                foreach (var item in medias)
                {
                    if (item.Description=="vignette")
                    {
                        imgVignette = item.Lien;
                    }
                    if (item.Description=="pano")
                    {
                        imgPano = item.Lien;
                    }
                    if (item.Video == true)
                    {
                        vid = item.Lien;
                    }
                }
                localisation = await LocalisationLogic.GetLocalisationBoutique(btqId);
            }
            return Page();
        }
    }
}
