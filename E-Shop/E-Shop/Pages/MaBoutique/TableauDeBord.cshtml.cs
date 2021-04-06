using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique
{
    public class TableauDeBordModel : PageModel
    {
        private CategorieLogic _categorieLogic = new CategorieLogic();
        private readonly UserManager<Partenaire> _userManager;
        public TableauDeBordModel(UserManager<Partenaire> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult OnPostLivraisonType()
        {
            return Redirect("/MaBoutique/LivraisonType/EditLivraisonType");
        }
        public IActionResult OnPostGestionProd()
        {
            return Redirect("/MaBoutique/LivraisonType/EditLivraisonType");
        }
        public async Task OnGetAsync()
        {
            //var user = await _userManager.FindByEmailAsync(User.Identity.Name);


        }
    }
}
