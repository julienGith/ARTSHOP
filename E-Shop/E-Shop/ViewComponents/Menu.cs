using E_Shop.Entities;
using E_Shop.Logic.CategorieLogic;
using E_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.ViewComponents
{
    public class Menu : ViewComponent
    {
        private CategorieLogic categorieLogic = new CategorieLogic();
        public MenuCat menuCat = new MenuCat();
        public CatSubCat CatSubCat = new CatSubCat();

        public List<Categorie> categories = new List<Categorie>();

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            categories = await categorieLogic.GetAllCategories();
            menuCat.CatParentsAlim = await categorieLogic.GetAllCategoriesParentsAlim();
            return View("Menu",menuCat);
        }
    }
}
