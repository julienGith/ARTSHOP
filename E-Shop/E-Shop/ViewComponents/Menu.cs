﻿using E_Shop.Logic.CategorieLogic;
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
        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            menuCat.CatParentsAlim = await categorieLogic.GetAllCategoriesParentsAlim();
            foreach (var item in menuCat.CatParentsAlim)
            {
                menuCat.CatEnfants1 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);

            }

            return View("Menu",menuCat);
        }
    }
}
