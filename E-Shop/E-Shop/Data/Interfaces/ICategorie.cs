using E_Shop.Entities;
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
    }
}
