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
        [BindProperty]
        public int lvrTypeId { get; set; }
        public int userId { get; set; }


        public IActionResult OnPostCrLivraisonType()
        {
            HttpContext.Session.Set<int>("lvrTypeId", 0);

            return Redirect("/MaBoutique/LivraisonType/EditLivraisonType");
        }
        public IActionResult OnPostUpLivraisonType()
        {
            HttpContext.Session.Set<int>("lvrTypeId", lvrTypeId);
            return Redirect("/MaBoutique/LivraisonType/EditLivraisonType");
        }
        public async Task<IActionResult> OnPostDelLivraisonType()
        {
            HttpContext.Session.Set<int>("lvrTypeId",0);

            await livraisonTypeLogic.DeleteLivraisonTypeById(lvrTypeId);
            if (HttpContext.Session.Get<int>("user") > 0)
            {
                userId = HttpContext.Session.Get<int>("user");
                Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByUserId(userId);
            }

            return Page();
        }
        public async Task<IActionResult> OnGet()
        {

            if (HttpContext.Session.Get<int>("user") > 0)
            {
                userId = HttpContext.Session.Get<int>("user");
                Livraisontypes = await livraisonTypeLogic.GetLivraisonTypeByUserId(userId);
            }
            return Page();
        }
    }
}
