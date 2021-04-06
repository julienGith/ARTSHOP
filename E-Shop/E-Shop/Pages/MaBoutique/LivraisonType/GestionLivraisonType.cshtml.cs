using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.LivraisonType
{
    public class GestionLivraisonTypeModel : PageModel
    {
        public List<Livraisontype> Livraisontypes { get; set; }
        public void OnGet()
        {

            if (HttpContext.Session.Get<string>("user") != null)
            {
                var userId = HttpContext.Session.Get<string>("user");

            }
        }
    }
}
