﻿using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface ILivraisonType
    {
        //CRUD LivraisonType
        //Création LivraisonType
        Task<Livraisontype> AddLivraisonType(int btqId, string lvrDésignation, short lvrDelai, decimal lvrCout, decimal lvrCoutPsup);
        //Add livraisonType à un Produit
        Task<Livraisontype> AddLivraisonTypeProduit(int lvrTypeId, int prodId);
        //Update LivraisonType
        Task<Livraisontype> UpdateLivraisonType(int lvrTypeId, string lvrDésignation, short lvrDelai, decimal lvrCout, decimal lvrCoutPsup);

        //Recherche LivraisonType
        //Get LivraisonType par Boutique
        Task<List<Livraisontype>> GetLivraisonTypeByBoutique(int btqId);
        //Get LivraisonType by Id
        Task<Livraisontype> GetLivraisonTypeById(int lvrTypId);
    }
}