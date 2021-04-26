using E_Shop.Entities;
using E_Shop.Logic.CategorieLogic;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Shop.ViewComponents
{
    public class MenuCatAlim : ViewComponent
    {
        StringBuilder stringBuilder = new StringBuilder();

        private CategorieLogic categorieLogic = new CategorieLogic();
        public List<Categorie> CatParentsAlim = new List<Categorie>();
        public List<Categorie> CatEnfants1 = new List<Categorie>();
        public List<Categorie> CatEnfants2 = new List<Categorie>();

        public async Task<HtmlContentViewComponentResult> InvokeAsync()
        {
            var Code = await Menu();
            return new HtmlContentViewComponentResult(new HtmlString(Code));
        }
        private async Task<string> Menu()
        { 
            stringBuilder.Append($"<nav class='navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3'>" +
                $"<div class='container'><button class='navbar-toggler' type='button' data-toggle='collapse' data-target='.navbar-collapse' aria-controls='navbarSupportedContent' aria-expanded='false' aria-label='Toggle navigation'>" +
                $"<span class='navbar-toggler-icon'></span></button>" +
                $"<div class='navbar-collapse collapse d-sm-inline-flex justify-content-between'><div class='navbar-nav center'><ul class='navbar-nav flex-grow-1'>" +
                $"");
            CatParentsAlim = await categorieLogic.GetAllCategoriesParentsAlim();
            foreach (var item in CatParentsAlim)
            {
                CatEnfants1 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);
                stringBuilder.Append($"<li class='nav-item dropdown'><a class='nav-link dropdown-toggle'" +
                    $"  id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>{item.Categorienom}</a>");
                if (CatEnfants1.Count > 0)
                {
                    stringBuilder.Append($"<div class='dropdown-menu' aria-labelledby='navbarDropdown'>");
                    foreach (var catenfant1 in CatEnfants1)
                    {
                        CatEnfants2 = await categorieLogic.GetAllCategoriesEnfantsByParentId(catenfant1.Categorieid);
                        if (CatEnfants2.Count > 0)
                        {
                            stringBuilder.Append($"<ul class='navbar-nav flex-grow-1'><li class='nav-item dropdown'><a class='nav-link dropdown-toggle' id='navbarDropdown' role='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false'>{catenfant1.Categorienom}</a>" +
                                $"<div class='dropdown-menu' aria-labelledby='navbarDropdown'>");
                            foreach (var catenfant2 in CatEnfants2)
                            {
                                stringBuilder.Append($"<a class='dropdown-item' href='/Produits/ListeProduits/?catId={catenfant2.Categorieid}'>{catenfant2.Categorienom}</a>");
                            }
                            stringBuilder.Append($"</div></li></ul>");

                        }
                        else
                        {
                            stringBuilder.Append($"<a class='dropdown-item' href='/Produits/ListeProduits/?catId={catenfant1.Categorieid}'>{catenfant1.Categorienom}</a>");

                        }
                    }
                    stringBuilder.Append($"</div></li>");
                }
            }
            //foreach (var item in CatEnfants1)
            //{
            //    CatEnfants2 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);
            //    if (CatEnfants2.Count>0)
            //    {
            //        stringBuilder.Append($"<div class='dropdown-menu' aria-labelledby='navbarDropdown'>");
            //        foreach (var catenfant2 in CatEnfants2)
            //        {
            //            stringBuilder.Append($"<a class='dropdown-item' href='/Produits/ListeProduits/?catId={catenfant2.Categorieid}'>{catenfant2.Categorienom}</a>");
            //        }
            //        stringBuilder.Append($"</div></li>");
            //    }
            //}
            stringBuilder.Append($"</ul></div></div></div></nav>");
            return stringBuilder.ToString();
        }
    }
}
