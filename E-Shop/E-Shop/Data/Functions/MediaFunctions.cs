﻿using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class MediaFunctions : IMedia
    {
        //CRUD Médias
        //Add Boutique Médias
        public async Task<Medium> AddBoutiqueMedias(int boutiqueId,string lien, bool image, bool video, string description, string LienComplet)
        {
            Medium media = new Medium();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                media.Btqid = boutiqueId;
                media.Lien = lien;
                media.Image = image;
                media.Video = video;
                media.Description = description;
                media.LienComplet = LienComplet;
                await context.Media.AddAsync(media);
                await context.SaveChangesAsync();
            }
            return media;
        }
        //Add Produit Médias
        public async Task<Medium> AddProduitMedias(int prodId, string lien, bool image, bool video, string description, string LienComplet)
        {
            Medium media = new Medium();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                media.Prodid = prodId;
                media.Lien = lien;
                media.Image = image;
                media.Video = video;
                media.Description = description;
                media.LienComplet = LienComplet;
                await context.Media.AddAsync(media);
                await context.SaveChangesAsync();
            }
            return media;
        }
        //Delete Media
        public async Task<Boolean> DeleteMedia(int mediaId)
        {
            Medium media = new Medium();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                media = await context.Media.FirstOrDefaultAsync(m => m.Mediaid == mediaId);
                if (System.IO.File.Exists(media.LienComplet))
                {
                    System.IO.File.Delete(media.LienComplet);
                }
                context.Media.Remove(media);

            }
            return true;
        }
        //Get Medias d'une boutique
        public async Task<List<Medium>> GetMediasBoutique(int btqId)
        {
            List<Medium> medias = new List<Medium>();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                medias = await context.Media.Where(m => m.Btqid == btqId).ToListAsync();
            }
            return medias;
        }
    }
}
