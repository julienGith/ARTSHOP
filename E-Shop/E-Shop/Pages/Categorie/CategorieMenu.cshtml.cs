using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Categorie
{
    public class CategorieMenuModel : PageModel
    {
        StringBuilder stringBuilder = new StringBuilder();

        private CategorieLogic categorieLogic = new CategorieLogic();
        public List<Entities.Categorie> CatParentsAlim = new List<Entities.Categorie>();
        public List<Entities.Categorie> CatEnfants1 = new List<Entities.Categorie>();
        public List<Entities.Categorie> CatEnfants2 = new List<Entities.Categorie>();

        public string code { get; set; }

        public async Task OnGet()
        {
            //stringBuilder.Append($"<nav class='navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3'>" +
            //    $"<button class='navbar-toggler' type='button' data-toggle='collapse' data-target='.navbar-collapse' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>" +
            //    $"<span class='navbar-toggler-icon'></span></button>" +
            //    $"<div class='navbar-collapse collapse d-sm-inline-flex justify-content-between'><ul class='navbar-nav flex-grow-1'>");
            CatParentsAlim = await categorieLogic.GetAllCategoriesParentsAlim();
            foreach (var item in CatParentsAlim)
            {
                CatEnfants1 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);
                stringBuilder.Append($"<li class='nav-item dropdown'><a class='nav-link dropdown-toggle'" +
                    $" href='#' id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>{item.Categorienom}</a>");
                if (CatEnfants1.Count -1>0)
                {
                    stringBuilder.Append($"<div class='dropdown-menu' aria-labelledby='navbarDropdown'>");
                    foreach (var catenfant1 in CatEnfants1)
                    {
                        stringBuilder.Append($"<a class='dropdown-item' href='#'>{catenfant1.Categorienom}</a>");
                    }
                    stringBuilder.Append($"</div>");
                }
            }
            foreach (var item in CatEnfants1)
            {
                CatEnfants2 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);
            }
            //stringBuilder.Append($"</ul></div></nav>");
            code = stringBuilder.ToString();
        }
    }
}
