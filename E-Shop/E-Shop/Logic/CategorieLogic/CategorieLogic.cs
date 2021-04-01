using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.CategorieLogic
{
    public class CategorieLogic
    {
        private ICategorie Categorie = new CategrieFunctions();
        //CRUD
        //Créer une catégorie
        public async Task<Categorie> AddCategorie(string catNom, int? CatParentID)
        {
            return await Categorie.AddCategorie(catNom, CatParentID);
        }
    }
}
