using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using E_Shop.Entities;
using E_Shop.Extensions;
using E_Shop.Logic;
using E_Shop.Logic.MediaLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.GestionBoutique
{
    public class MediasModel : PageModel
    {
        private IWebHostEnvironment _webHostEnvironment;
        public MediasModel (IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        private MediaLogic mediaLogic = new MediaLogic();
        public List<Medium> medias = new List<Medium>();

        public int boutiqueId { get; set; }
        public int mediaId { get; set; }
        [BindProperty]
        public string FileNameImg { get; set; }
        public string Lien { get; set; }


        public async Task<IActionResult> OnPostImgV(IFormFile photo, int mediaId)
        {
            await mediaLogic.DeleteMedia(mediaId);
            if (photo == null || photo.Length == 0)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await photo.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    var newimg = Imager.Resize(img, 125, 125, false);
                    var newname = Guid.NewGuid().ToString() + ".jpeg";
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname);
                    Imager.SaveJpeg(path, newimg);
                    Lien = "/images/" + newname;
                    await mediaLogic.AddBoutiqueMedias(boutiqueId, Lien, true, false, "vignette");
                    medias = await mediaLogic.GetMediasBoutique(boutiqueId);

                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostImgP(IFormFile photo, int mediaId)
        {
            await mediaLogic.DeleteMedia(mediaId);
            if (photo == null || photo.Length == 0)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await photo.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    var newimg = Imager.Resize(img, 125, 125, false);
                    var newname = Guid.NewGuid().ToString() + ".jpeg";
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname);
                    Imager.SaveJpeg(path, newimg);
                    Lien = "/images/" + newname;
                    await mediaLogic.AddBoutiqueMedias(boutiqueId, Lien, true, false, "pano");
                    medias = await mediaLogic.GetMediasBoutique(boutiqueId);

                }
            }
            return Page();
        }
        public async Task<IActionResult> OnPostVid(int mediaId)
        {
            await mediaLogic.DeleteMedia(mediaId);
            Lien = GetYoutubeId(FileNameImg);
            await mediaLogic.AddBoutiqueMedias(boutiqueId, Lien, false, true, "");
            medias = await mediaLogic.GetMediasBoutique(boutiqueId);

            return Page();
        }
        private string GetYoutubeId(string lien)
        {
            string pattern = @"(?:https?:\/\/)?(?:www\.)?(?:(?:(?:youtube.com\/watch\?[^?]*v=|youtu.be\/)([\w\-]+))(?:[^\s?]+)?)";
            string replacement = "https://www.youtube.com/embed/$1";
            var rgx = new Regex(pattern);
            var result = rgx.Replace(lien, replacement);
            return result;
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("btqId") > 0)
            {
                boutiqueId = HttpContext.Session.Get<int>("btqId");
                medias = await mediaLogic.GetMediasBoutique(boutiqueId);
            }
            return Page();
        }
    }
}