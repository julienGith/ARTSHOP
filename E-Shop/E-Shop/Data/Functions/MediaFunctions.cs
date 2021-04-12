using E_Shop.Data.Interfaces;
using E_Shop.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace E_Shop.Data.Functions
{
    public class MediaFunctions : IMedia
    {
        private IWebHostEnvironment _webHostEnvironment;
        public MediaFunctions(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        //CRUD Médias
        //Add Boutique Médias
        public async Task<Medium> AddBoutiqueMedias(int boutiqueId,string lien, bool image, bool video, string description, string fileName)
        {
            Medium media = new Medium();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                media.Btqid = boutiqueId;
                media.Lien = lien;
                media.Image = image;
                media.Video = video;
                media.Description = description;
                media.FileName = fileName;
                await context.Media.AddAsync(media);
                await context.SaveChangesAsync();
            }
            return media;
        }
        //Add Produit Médias
        public async Task<Medium> AddProduitMedias(int prodId, string lien, bool image, bool video, string description, string fileName)
        {
            Medium media = new Medium();
            using (var context = new ApplicationDbContext(ApplicationDbContext.ops.dbOptions))
            {
                media.Prodid = prodId;
                media.Lien = lien;
                media.Image = image;
                media.Video = video;
                media.Description = description;
                media.FileName = fileName;
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
                var LienComplet = Path.Combine(Directory.GetCurrentDirectory(),
                        _webHostEnvironment.WebRootPath, "images\\", media.FileName);
                if (System.IO.File.Exists(LienComplet))
                {
                    System.IO.File.Delete(LienComplet);
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
