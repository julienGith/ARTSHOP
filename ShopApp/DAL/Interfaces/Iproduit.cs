﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface Iproduit
    {        
        //CRUD Produit
        //Add New Produit
        Task<Produit> AddProduit(int Btqid, int Categorieid, int Livrtypid, decimal Prix, string Nom, string DescriptionC, string DescriptionL,
            short Stock, short Disponibilite, short Rabais, short Preparation, string Pseo, string PMetaKeywords, string PMetaTitre, bool Publier);
        //Update Produit
        Task<Boolean> UpdateProduit(string Prodid, int Categorieid, int Livrtypid, decimal Prix, string Nom, string DescriptionC, string DescriptionL,
    short Stock, short Disponibilite, short Rabais, short Preparation, string Pseo, string PMetaKeywords, string PMetaTitre, bool Publier);

        //Recherche Produit
        //Get All Produits
        Task<List<Produit>> GetAllProduits();
        //Par mot clé
        Task<List<Produit>> GetProduitsKW(string query);
        //Par ID produit
        Task<Produit> GetProduitID(string query);
    }
}
