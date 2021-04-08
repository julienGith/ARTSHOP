using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.ProduitLogic
{
    public class ProduitLogic
    {
        IProduit produit = new ProduitFunctions();
        //CRUD Produit
        //Add New Produit
        public async Task<Produit> AddProduit(int boutiqueId, int categorieId, decimal? prix, string nom, string descriptionC, string descriptionL,
            short? stock, short? disponibilite, short? rabais, short? preparation, bool? publier, int? poids)
        {
            return await produit.AddProduit(boutiqueId, categorieId, prix, nom, descriptionC, descriptionL, stock, disponibilite, rabais, preparation, publier, poids);
        }
        //Modifier Produit
        public async Task<Produit> UpdateProduit(int prodId, int categorieId, decimal? prix, string nom, string descriptionC, string descriptionL,
            short? stock, short? disponibilite, short? rabais, short? preparation, bool? publier, int? poids)
        {
            return await produit.UpdateProduit(prodId, categorieId, prix, nom, descriptionC, descriptionL, stock, disponibilite, rabais, preparation, publier, poids);
        }
        //Delete Produit
        public async Task<Boolean> DeleteProduit(int prodId)
        {
            return await produit.DeleteProduit(prodId);
        }

        //Recherche Produit
        //Produits par boutique
        public async Task<List<Produit>> GetBoutiqueProduits(int btqId)
        {
            return await produit.GetBoutiqueProduits(btqId);
        }
        //Nom du produit par id produit
        public string GetNomProduitById(int prodId)
        {
            return produit.GetNomProduitById(prodId);
        }
    }
}
