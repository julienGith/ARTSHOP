using E_Shop.Entities;
using E_Shop.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface IProduit
    {       
        //CRUD Produit
        //Add New Produit
        Task<Produit> AddProduit(int boutiqueId, int categorieId, string nom, string descriptionC, string descriptionL,
            short? stock, short? disponibilite, short? rabais, short? preparation, bool publier);
        //Modifier Produit
        Task<Produit> UpdateProduit(Produit produit);
        //Delete Produit
        Task<Boolean> DeleteProduit(int prodId);

        //Recherche Produit
        //Produits par boutique
        Task<List<Produit>> GetBoutiqueProduits(int btqId);
        //Get produit par id produit
        Task<Produit> GetProduitById(int prodId);
        //Nom du produit par id produit
        Task<string> GetNomProduitById(int prodId);
        //Get produits par catégorie
        Task<PaginatedList<Produit>> GetProduitsByCatId(int catId, int? pageIndex, string sortOrder);
        //Recherche partielle produits par nom
        Task<List<Produit>> GetListProduitByQuery(string query);
    }
}
