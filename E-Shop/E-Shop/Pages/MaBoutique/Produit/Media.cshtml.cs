using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string FileNameImg { get; set; }
        [BindProperty]
        public string Lien { get; set; }
        public string nomProd { get; set; }
        public int mediaId { get; set; }

        public async Task<IActionResult> OnPostImg(IFormFile photo)
        {
            if (ModelState.IsValid)
            {
                if (HttpContext.Session.Get<int>("prodIdUp") > 0)
                {
                    prodId = HttpContext.Session.Get<int>("prodIdUp");
                    nomProd = ProduitLogic.GetNomProduitById(prodId);
                    var result = await mediaLogic.GetMediasByProdId(prodId);
                    foreach (var item in result)
                    {
                        await mediaLogic.DeleteMedia(item.Mediaid, _webHostEnvironment);
                    }
                }
                else if (HttpContext.Session.Get<int>("prodId") > 0)
                {
                    prodId = HttpContext.Session.Get<int>("prodId");
                    nomProd = ProduitLogic.GetNomProduitById(prodId);
                    var result = await mediaLogic.GetMediasByProdId(prodId);
                    if (result != null)
                    {
                        foreach (var item in result)
                        {
                            await mediaLogic.DeleteMedia(item.Mediaid, _webHostEnvironment);
                        }
                    }
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
                        var newimg1 = Imager.Resize(img, 480, 360, false);
                        var newimg2 = Imager.Resize(img, 270, 200, false);
                        var newimg3 = Imager.Resize(img, 89, 65, false);

                        var newname1 = Guid.NewGuid().ToString() + ".jpeg";
                        var newname2 = Guid.NewGuid().ToString() + ".jpeg";
                        var newname3 = Guid.NewGuid().ToString() + ".jpeg";

                        var path1 = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname1);
                        Imager.SaveJpeg(path1, newimg1);
                        var path2 = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname2);
                        Imager.SaveJpeg(path2, newimg2);
                        var path3 = Path.Combine(_webHostEnvironment.WebRootPath, "images", newname3);
                        Imager.SaveJpeg(path3, newimg3);
                        Lien = "/images/" + newname1;
                        await mediaLogic.AddProduitMedias(prodId, Lien, true, false, nomProd, newname1);
                        await mediaLogic.AddProduitMedias(prodId, "/images/" + newname2, true, false, "mid", newname2);
                        await mediaLogic.AddProduitMedias(prodId, "/images/" + newname3, true, false, "min", newname3);

                    }
                }
                return Page();
            }
            return Page();
        }
        public async Task<IActionResult> OnGet()
        {
            if (HttpContext.Session.Get<int>("prodIdUp")>0)
            {
                prodId = HttpContext.Session.Get<int>("prodIdUp");
                var result = await mediaLogic.GetMediasByProdId(prodId);
                foreach (var item in result)
                {
                    if (item.Description != "mid" && item.Description!="min")
                    {
                        Lien = item.Lien;
                    }
                }
            }
            else if (HttpContext.Session.Get<int>("prodId") > 0)
            {
                prodId = HttpContext.Session.Get<int>("prodId");
                nomProd = ProduitLogic.GetNomProduitById(prodId);
            }
            return Page();
        }
    }
}
