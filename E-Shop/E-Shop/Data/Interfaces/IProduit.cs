﻿using E_Shop.Entities;
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
            short? stock, short? disponibilite, short? rabais, short? preparation, bool? publier, int? poids);
        //Modifier Produit
        Task<Produit> UpdateProduit(int prodId, int categorieId, decimal? prix, string nom, string descriptionC, string descriptionL,
            short? stock, short? disponibilite, short? rabais, short? preparation, bool? publier, int? poids);
        //Delete Produit
        Task<Boolean> DeleteProduit(int prodId);

        //Recherche Produit
        //Produits par boutique
        Task<List<Produit>> GetBoutiqueProduits(int btqId);
        //Nom du produit par id produit
        string GetNomProduitById(int prodId);
    }
}
