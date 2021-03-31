﻿using E_Shop.Data.Functions;
using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Logic.MediaLogic
{
    public class MediaLogic
    {
        private IMedia _media = new MediaFunctions();
        //CRUD Médias
        //Add Boutique Médias
        public async Task<Medium> AddBoutiqueMedias(int boutiqueId, string lien, bool image, bool video, string description)
        {
            return await _media.AddBoutiqueMedias(boutiqueId, lien, image, video, description);
        }
        public async Task<Boolean> DeleteMedia(int mediaId)
        {
            return await _media.DeleteMedia(mediaId);
        }
    }
}