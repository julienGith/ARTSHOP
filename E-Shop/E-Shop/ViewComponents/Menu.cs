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

        public async Task<ViewViewComponentResult> InvokeAsync()
        {
            menuCat.CatParentsAlim = await categorieLogic.GetAllCategoriesParentsAlim();
            foreach (var item in menuCat.CatParentsAlim)
            {

                menuCat.CatEnfants1 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);
                foreach (var cat1 in menuCat.CatEnfants1)
                {

                    menuCat.CatEnfants2 = await categorieLogic.GetAllCategoriesEnfantsByParentId(cat1.Categorieid);

                    foreach (var cat2 in menuCat.CatEnfants2)
                    {
                        CatSubCat CatSubCat = new CatSubCat
                        {
                            catParent = item,
                            catEnfants = menuCat.CatEnfants1,
                            subCats = menuCat.CatEnfants2
                        };
                        menuCat.CatSubCats.Add(CatSubCat);
                    }
                }
            }

            return View("Menu",menuCat);
        }
    }
}
