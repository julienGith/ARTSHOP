using E_Shop.Entities;
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
        Task<Livraisontype> AddLivraisonType(int btqId, string lvrDésignation, short? lvrDelai, decimal? lvrCout, decimal? lvrCoutPsup);
        //Add livraisonType à un Produit
        Task<ProdLvrType> AddLivraisonTypeProduit(int lvrTypeId, int prodId);
        //Remove livraisonType à un Produit
        Task<Boolean> RemoveLivraisonTypeProduit(int lvrTypeId);
        //Update LivraisonType
        Task<Livraisontype> UpdateLivraisonType(int lvrTypeId, string lvrDésignation, short? lvrDelai, decimal? lvrCout, decimal? lvrCoutPsup);
        //Delete LivraisonType
        Task<Boolean> DeleteLivraisonTypeById(int lvrTypId);

        //Recherche LivraisonType
        //Get LivraisonType par Boutique
        Task<List<Livraisontype>> GetLivraisonTypeByBoutique(int btqId);
        //Get LivraisonType by Id
        Task<Livraisontype> GetLivraisonTypeById(int lvrTypId);
        //Get LivraisonType par userId
        Task<List<Livraisontype>> GetLivraisonTypeByUserId(int userId);
        //Get LivraisonType by prodId
        Task<List<Livraisontype>> GetLivraisontypeByProdId(int prodId);
    }
}
