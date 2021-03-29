using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using E_Shop.Extensions;
using Microsoft.AspNetCore.Identity;
using E_Shop.Entities;


namespace E_Shop.Pages.Boutique
{
    public class CreateBoutiqueStep1Model : PageModel
    {

        public IActionResult OnPostSuivant()
        {

            return RedirectToPage("/boutique/CreateBoutiqueStep2");


        }
        public IActionResult OnGet()
        {

            return Page();
        }
    }
}
