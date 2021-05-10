using E_Shop.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface ICategorie
    {
        //CRUD Categorie
        //Add new catégorie
        Task<Categorie> AddCategorie(string catNom, int? CatParentID);


        //Get all catégories
        Task<List<Categorie>> GetAllCategories();
        //Get Categories Dictionnary
        List<SelectListItem> GetSelectListItemCategories();
        //Get All categories parents alimentaires
        Task<List<Categorie>> GetAllCategoriesParentsAlim();
        //Get All categories enfants par id de catégorie parent
        Task<List<Categorie>> GetAllCategoriesEnfantsByParentId(int categorieParentId);
        //Get Categories parents SelectListItem
        Task<List<SelectListItem>> GetSelectListItemCategoriesParents();
        //Get Categories enfant SelectListItem
        Task<List<SelectListItem>> GetSelectListItemCategoriesEnfants(int categorieParentId);
        //Get catégories d'une boutique
        Task<List<Categorie>> GetCategoriesByBtqId(int btqId);
        //Get catégorie par catégorie Id
        Task<Categorie> GetCategorieById(int catid);
    }
}
