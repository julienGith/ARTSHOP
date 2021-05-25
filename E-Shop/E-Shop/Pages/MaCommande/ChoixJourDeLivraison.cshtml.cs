using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Data.Functions;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaCommande
{
    public class ChoixJourDeLivraisonModel : PageModel
    {
        private LivraisonTypeFunctions livraisonTypeFunctions = new LivraisonTypeFunctions();
        private readonly UserManager<Partenaire> _userManager;
        public ChoixJourDeLivraisonModel(UserManager<Partenaire> userManager)
        {
            _userManager = userManager;
        }
        public Cart cart = new Cart();
        public DateTime dateChoisie { get; set; }
        public int délaiMaxCommande { get; set; }
        public int délai { get; set; }
        public List<int> listeDélais = new List<int>();
        public Livraisontype livraisontype = new Livraisontype();
        public List<Livraisontype> livraisonstypeProd = new List<Livraisontype>();
        public void OnPost()
        {
            //var user = await _userManager.FindByEmailAsync(User.Identity.Name);

        }
        public async Task<IActionResult> OnGet()
        {

            //var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            cart = HttpContext.Session.Get<Models.Cart>("Cart");
            return Page();

        }
    }
}
