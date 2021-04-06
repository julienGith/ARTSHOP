using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.LivraisonTypeLogic
{
    public class LivraisonTypeLogic
    {
        private ILivraisonType livraisonType = new LivraisonTypeFunctions();
        //CRUD LivraisonType
        //Création LivraisonType
        public async Task<Livraisontype> AddLivraisonType(int btqId, string lvrDésignation, short lvrDelai, decimal lvrCout, decimal lvrCoutPsup)
        {
            return await livraisonType.AddLivraisonType(btqId, lvrDésignation, lvrDelai, lvrCout, lvrCoutPsup);
        }
        //Add livraisonType à un Produit
        public async Task<Livraisontype> AddLivraisonTypeProduit(int lvrTypeId, int prodId)
        {
            return await livraisonType.AddLivraisonTypeProduit(lvrTypeId, prodId);
        }
        //Get LivraisonType par Boutique
        public async Task<List<Livraisontype>> GetLivraisonTypeByBoutique(int btqId)
        {
            return await livraisonType.GetLivraisonTypeByBoutique(btqId);
        }
        //Get LivraisonType by Id
        public async Task<Livraisontype> GetLivraisonTypeById(int lvrTypId)
        {
            return await livraisonType.GetLivraisonTypeById(lvrTypId);
        }
    }
}
