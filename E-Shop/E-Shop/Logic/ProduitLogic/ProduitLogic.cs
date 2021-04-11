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
        IProduit _produit = new ProduitFunctions();
        //CRUD Produit
        //Add New Produit
        public async Task<Produit> AddProduit(int boutiqueId, int categorieId, decimal? prix, string nom, string descriptionC, string descriptionL,
            short? stock, short? disponibilite, short? rabais, short? preparation, bool? publier, int? poids1, int poids2, int poids3)
        {
            return await _produit.AddProduit(boutiqueId, categorieId, prix, nom, descriptionC, descriptionL, stock, disponibilite, rabais, preparation, publier, poids1, poids2, poids3);
        }
        //Modifier Produit
        public async Task<Produit> UpdateProduit(Produit produit)
        {
            return await _produit.UpdateProduit(produit);
        }
        //Delete Produit
        public async Task<Boolean> DeleteProduit(int prodId)
        {
            return await _produit.DeleteProduit(prodId);
        }

        //Recherche Produit
        //Produits par boutique
        public async Task<List<Produit>> GetBoutiqueProduits(int btqId)
        {
            return await _produit.GetBoutiqueProduits(btqId);
        }
        //Get produit par id produit
        public async Task<Produit> GetProduitById(int prodId)
        {
            return await _produit.GetProduitById(prodId);
        }
        //Nom du produit par id produit
        public string GetNomProduitById(int prodId)
        {
            return _produit.GetNomProduitById(prodId);
        }
    }
}
