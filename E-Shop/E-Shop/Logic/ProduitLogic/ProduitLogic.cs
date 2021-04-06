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
        public async Task<Produit> AddProduit(int boutiqueId, int categorieId, decimal prix, string nom, string descriptionC, string descriptionL,
            short stock, short disponibilite, short rabais, short preparation, string seo, string metaKw, string metaTitre, bool publier)
        {
            return await produit.AddProduit(boutiqueId, categorieId, prix, nom, descriptionC, descriptionL, stock, disponibilite, rabais, preparation, seo, metaKw, metaTitre, publier);
        }
        //Modifier Produit
        public async Task<Produit> UpdateProduit(int prodId, int categorieId, int livraisonTypeId, decimal prix, string nom, string descriptionC, string descriptionL,
            short stock, short disponibilite, short rabais, short preparation, string seo, string metaKw, string metaTitre, bool publier)
        {
            return await produit.UpdateProduit(prodId, categorieId, prix, nom, descriptionC, descriptionL, stock, disponibilite, rabais, preparation, seo, metaKw, metaTitre, publier);
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
    }
}
