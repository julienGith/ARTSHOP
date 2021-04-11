using E_Shop.Entities;
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
        Task<Produit> AddProduit(int boutiqueId, int categorieId, decimal? prix, string nom, string descriptionC, string descriptionL,
            short? stock, short? disponibilite, short? rabais, short? preparation, bool? publier, int? poids1, int poids2, int poids3);
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
        string GetNomProduitById(int prodId);
    }
}
