using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using E_Shop.Extensions;
using E_Shop.Logic;
using E_Shop.Logic.MediaLogic;
using E_Shop.Logic.ProduitLogic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.MaBoutique.Produit
{
    public class MediaModel : PageModel
    {
        private ProduitLogic ProduitLogic = new ProduitLogic();

        private MediaLogic mediaLogic = new MediaLogic();
        private IWebHostEnvironment _webHostEnvironment;
        public MediaModel(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public int prodId { get; set; }
        [BindProperty]
        public string FileNameImg { get; set; }
        public string Lien { get; set; }
        public string nomProd { get; set; }
        public int mediaId { get; set; }

        public async Task<IActionResult> OnPostImg(IFormFile photo)
        {
            if (mediaId>0)
            {
                await mediaLogic.DeleteMedia(mediaId, _webHostEnvironment);

            }
            if (photo == null || photo.Length == 0)
            {
                return Page();
            }

            using (var memoryStream = new MemoryStream())
            {
                await photo.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    var newimg = Imager.Resize(img, 480, 360, false);
                    var newname = Guid.NewGuid().ToString() + ".jpeg";
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname);
                    Imager.SaveJpeg(path, newimg);
                    Lien = "/images/" + newname;
                    var result = await mediaLogic.AddProduitMedias(prodId, Lien, true, false, nomProd, newname);
                    mediaId = result.Mediaid;
                }
            }
            return Page();
        }
        public void OnGet()
        {
            if (HttpContext.Session.Get<int>("prodId") > 0)
            {
                prodId = HttpContext.Session.Get<int>("prodId");
                nomProd = ProduitLogic.GetNomProduitById(prodId);
            }
        }
    }
}
