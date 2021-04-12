using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.MediaLogic
{
    public class MediaLogic
    {
        private static IWebHostEnvironment _webHostEnvironment;

        private IMedia _media = new MediaFunctions(_webHostEnvironment);
        //CRUD Médias
        //Add Boutique Média
        public async Task<Medium> AddBoutiqueMedias(int boutiqueId, string lien, bool image, bool video, string description, string fileName)
        {
            return await _media.AddBoutiqueMedias(boutiqueId, lien, image, video, description, fileName);
        }
        //Add Produit Média
        public async Task<Medium> AddProduitMedias(int prodId, string lien, bool image, bool video, string description, string fileName)
        {
            return await _media.AddProduitMedias(prodId, lien, image, video, description, fileName);
        }
        //Delete Média
        public async Task<Boolean> DeleteMedia(int mediaId)
        {
            return await _media.DeleteMedia(mediaId);
        }
        //Get Medias d'une boutique
        public async Task<List<Medium>> GetMediasBoutique(int btqId)
        {
            return await _media.GetMediasBoutique(btqId);
        }
    }
}
