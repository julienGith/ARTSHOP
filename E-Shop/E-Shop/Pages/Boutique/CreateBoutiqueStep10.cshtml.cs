using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep10Model : PageModel
    {
        [BindProperty]
        public Step10 step10 { get; set; }

        public class Step10
        {
            public string Lien { get; set; }
            public int? Btqid { get; set; }
            public string Description { get; set; }
            public bool Image { get; set; }
            public bool Video { get; set; }
            public string Html { get; set; }
            [Display(Name = "Indiquer le lien vers votre vidéo de présentation de votre boutique")]
            public string VideoLink { get; set; }
        }
        public void OnGet()
        {
        }
    }
}
