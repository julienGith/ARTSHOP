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



        public async Task OnGet()
        {
            CatParentsAlim = await categorieLogic.GetAllCategoriesParentsAlim();
            foreach (var item in CatParentsAlim)
            {
                CatEnfants1 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);


            }
            foreach (var item in CatEnfants1)
            {
                CatEnfants2 = await categorieLogic.GetAllCategoriesEnfantsByParentId(item.Categorieid);
            }
        }
    }
}
