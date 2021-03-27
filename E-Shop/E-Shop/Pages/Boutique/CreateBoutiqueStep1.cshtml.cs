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
        private readonly UserManager<Partenaire> _userManager;

        public CreateBoutiqueStep1Model(UserManager<Partenaire> userManager)
        {
            _userManager = userManager;

        }

        [BindProperty]
        public Step1 step1 { get; set; }
        public class Step1
        {
            public int UserId { get; set; }

            [Required]
            [StringLength(500)]
            [Display(Name = "Description courte")]
            public string BDescriptionC { get; set; }
            [Required]
            [StringLength(4000)]
            [Display(Name = "Description Longue")]
            public string BDescriptionL { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Raison Sociale")]
            public string Raisonsociale { get; set; }
        }
        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(User.Identity.Name);
                step1.UserId = user.Id;
                HttpContext.Session.Set<Step1>("step1", step1);
                step1 = HttpContext.Session.Get<Step1>("step1");
                return RedirectToPage("/boutique/CreateBoutiqueStep2");
            }
            return Page();
            
        }
        public IActionResult OnGet()
        {
            if (HttpContext.Session.Get<Step1>("step1")!=null)
            {
                step1 = HttpContext.Session.Get<Step1>("step1");
            }

            return Page();
        }
    }
}
