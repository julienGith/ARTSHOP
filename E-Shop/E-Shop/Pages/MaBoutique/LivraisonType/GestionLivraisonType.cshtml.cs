using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic.LivraisonTypeLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.LivraisonType
{
    public class GestionLivraisonTypeModel : PageModel
    {
        private LivraisonTypeLogic livraisonTypeLogic = new LivraisonTypeLogic();
        public List<Livraisontype> Livraisontypes = new List<Livraisontype>();
        public int lvrTypeId { get; set; }

        public IActionResult OnPostCrLivraisonType()
        {
            return Redirect("/MaBoutique/LivraisonType/EditLivraison");
        }
        public IActionResult OnPostUpLivraisonType()
        {
            HttpContext.Session.Set<int>("lvrTypeId", lvrTypeId);
            return Redirect("/MaBoutique/LivraisonType/EditLivraison");
        }
        public async Task<IActionResult> OnPostDelLivraisonType()
        {
            await livraisonTypeLogic.DeleteLivraisonTypeById(lvrTypeId);
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {

            if (HttpContext.Session.Get<int>("user") > 0)
            {
                var userId = HttpContext.Session.Get<int>("user");
                Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByUserId(userId);
            }
            return Page();
        }
    }
}
