using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.CategorieLogic
{
    public class CategorieLogic
    {
        private ICategorie Categorie = new CategorieFunctions();
        //CRUD
        //Créer une catégorie
        public async Task<Categorie> AddCategorie(string catNom, int? CatParentID)
        {
            return await Categorie.AddCategorie(catNom, CatParentID);
        }
        //Get all categories
        public async Task<List<Categorie>> GetAllCategories()
        {
            return await Categorie.GetAllCategories();
        }
        //Get Categories SelectListItem
        public List<SelectListItem> GetSelectListItemCategories()
        {
            return  Categorie.GetSelectListItemCategories();
        }
        //Get All categories parents alimentaires
        public async Task<List<Categorie>> GetAllCategoriesParentsAlim()
        {
            return await Categorie.GetAllCategoriesParentsAlim();
        }
        //Get All categories enfants par id de catégorie parent
        public async Task<List<Categorie>> GetAllCategoriesEnfantsByParentId(int categorieParentId)
        {
            return await Categorie.GetAllCategoriesEnfantsByParentId(categorieParentId);
        }
        //Get All categories parents par id de catégorie enfant
        public async Task<List<Categorie>> GetAllCategoriesParentsByEnfantId(int categorieEnfantId)
        {
            return await Categorie.GetAllCategoriesParentsByEnfantId(categorieEnfantId);
        }
        //Get Categories parents SelectListItem
        public async Task<List<SelectListItem>> GetSelectListItemCategoriesParents()
        {
            return await Categorie.GetSelectListItemCategoriesParents();
        }
        //Get Categories enfant SelectListItem
        public async Task<List<SelectListItem>> GetSelectListItemCategoriesEnfants(int categorieParentId)
        {
            return await Categorie.GetSelectListItemCategoriesEnfants(categorieParentId);
        }
        //Get catégories d'une boutique
        public async Task<List<Categorie>> GetCategoriesByBtqId(int btqId)
        {
            return await Categorie.GetCategoriesByBtqId(btqId);
        }
        //Get catégorie par catégorie Id
        public async Task<Categorie> GetCategorieById(int catid)
        {
            return await Categorie.GetCategorieById(catid);
        }
    }
}
