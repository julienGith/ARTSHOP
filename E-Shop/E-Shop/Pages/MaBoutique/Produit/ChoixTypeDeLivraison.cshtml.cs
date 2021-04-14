using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.LivraisonTypeLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class ChoixTypeDeLivraisonModel : PageModel
    {
        private LivraisonTypeLogic livraisonTypeLogic = new LivraisonTypeLogic();

        public List<Livraisontype> Livraisontypes = new List<Livraisontype>();
        public List<Livraisontype> LivraisontypesChoisies = new List<Livraisontype>();
        public Livraisontype Livraisontype = new Livraisontype();
        [BindProperty]
        public int lvrTypeIdChoisie { get; set; }
        [BindProperty]
        public int lvrTypeIdSelect { get; set; }


        public int lvrTypeId { get; set; }
        public int btqId { get; set; }
        public async Task<IActionResult> OnPostAdd()
        {
            if (HttpContext.Session.Get<int>("prodIdUp") > 0)
            {
                var prodId = HttpContext.Session.Get<int>("prodIdUp");
                await livraisonTypeLogic.AddLivraisonTypeProduit(lvrTypeIdChoisie, prodId);
                LivraisontypesChoisies = await livraisonTypeLogic.GetLivraisontypeByProdId(prodId);
                if (HttpContext.Session.Get<int>("btqId") > 0)
                {
                    btqId = HttpContext.Session.Get<int>("btqId");
                    Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByBoutique(btqId);
                }
                return Page();
            }
            if (HttpContext.Session.Get<int>("prodId")>0)
            {
                var prodId = HttpContext.Session.Get<int>("prodId");
                await livraisonTypeLogic.AddLivraisonTypeProduit(lvrTypeIdChoisie, prodId);
                LivraisontypesChoisies = await livraisonTypeLogic.GetLivraisontypeByProdId(prodId);
                if (HttpContext.Session.Get<int>("btqId") > 0)
                {
                    btqId = HttpContext.Session.Get<int>("btqId");
                    Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByBoutique(btqId);
                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostDel()
        {
            if (HttpContext.Session.Get<int>("prodIdUp") > 0)
            {
                await livraisonTypeLogic.RemoveLivraisonTypeProduit(lvrTypeIdSelect);
                Livraisontype = await livraisonTypeLogic.GetLivraisonTypeById(lvrTypeIdSelect);
                LivraisontypesChoisies.Remove(Livraisontype);
                if (HttpContext.Session.Get<int>("btqId") > 0)
                {
                    btqId = HttpContext.Session.Get<int>("btqId");
                    Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByBoutique(btqId);
                }
            }
            if (HttpContext.Session.Get<int>("prodId") > 0)
            {
                await livraisonTypeLogic.RemoveLivraisonTypeProduit(lvrTypeIdSelect);
                Livraisontype = await livraisonTypeLogic.GetLivraisonTypeById(lvrTypeIdSelect);
                LivraisontypesChoisies.Remove(Livraisontype);
                if (HttpContext.Session.Get<int>("btqId") > 0)
                {
                    btqId = HttpContext.Session.Get<int>("btqId");
                    Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByBoutique(btqId);
                }
            }

            return Page();
        }
        public IActionResult OnPostNext()
        {
            return Redirect("/MaBoutique/Produit/Media");
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("prodIdUp") > 0)
            {
                var prodId = HttpContext.Session.Get<int>("prodId");
                LivraisontypesChoisies = await livraisonTypeLogic.GetLivraisontypeByProdId(prodId);
            }
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                btqId = HttpContext.Session.Get<int>("btqId");
                Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByBoutique(btqId);
            }
            return Page();
        }
    }
}
