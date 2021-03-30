using E_Shop.Data.Interfaces;
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
        public async Task<Medium> AddBoutiqueMedias(int boutiqueId,string lien, bool image, bool video, string description)
        {
            Medium media = new Medium();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                media.Btqid = boutiqueId;
                media.Lien = lien;
                media.Image = image;
                media.Video = video;
                media.Description = description;
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
                if (System.IO.File.Exists(media.Lien))
                {
                    System.IO.File.Delete(media.Lien);
                }
                context.Media.Remove(media);

            }
            return true;
        }
    }
}
