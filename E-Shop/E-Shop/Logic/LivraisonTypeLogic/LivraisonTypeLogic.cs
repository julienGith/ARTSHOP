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
        public async Task<Livraisontype> AddLivraisonType(int btqId, string lvrDésignation, short? lvrDelai, decimal? lvrCout, decimal? lvrCoutPsup)
        {
            return await livraisonType.AddLivraisonType(btqId, lvrDésignation, lvrDelai, lvrCout, lvrCoutPsup);
        }
        //Add livraisonType à un Produit
        public async Task<Livraisontype> AddLivraisonTypeProduit(int lvrTypeId, int prodId)
        {
            return await livraisonType.AddLivraisonTypeProduit(lvrTypeId, prodId);
        }
        //Remove livraisonType à un Produit
        public async Task<Livraisontype> RemoveLivraisonTypeProduit(int lvrTypeId)
        {
            return await livraisonType.RemoveLivraisonTypeProduit(lvrTypeId);
        }
        //Update LivraisonType
        public async Task<Livraisontype> UpdateLivraisonType(int lvrTypeId, string lvrDésignation, short? lvrDelai, decimal? lvrCout, decimal? lvrCoutPsup)
        {
            return await livraisonType.UpdateLivraisonType(lvrTypeId, lvrDésignation, lvrDelai, lvrCout, lvrCoutPsup);
        }
        //Delete LivraisonType
        public async Task<Boolean> DeleteLivraisonTypeById(int lvrTypId)
        {
            return await livraisonType.DeleteLivraisonTypeById(lvrTypId);
        }


        //Recherche LivraisonType
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
        //Get LivraisonType par userId
        public async Task<List<Livraisontype>> GetLivraisonTypeByUserId(int userId)
        {
            return await livraisonType.GetLivraisonTypeByUserId(userId);
        }
        //Get LivraisonType by prodId
        public async Task<List<Livraisontype>> GetLivraisontypeByProdId(int prodId)
        {
            return await livraisonType.GetLivraisontypeByProdId(prodId);
        }
    }
}
