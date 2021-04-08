using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Interfaces
{
    public interface IMedia
    {
        //CRUD Médias
        //Add Boutique Médias
        Task<Medium> AddBoutiqueMedias(int boutiqueId, string lien, bool image, bool video, string description);
        //Delete Media
        Task<Boolean> DeleteMedia(int mediaId);
        //Add Produit Médias
        Task<Medium> AddProduitMedias(int prodId, string lien, bool image, bool video, string description);
        //Get Medias d'une boutique
        Task<List<Medium>> GetMediasBoutique(int btqId);
    }
}
