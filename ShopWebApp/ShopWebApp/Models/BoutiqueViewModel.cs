using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWebApp.Models
{
    public class BoutiqueViewModel
    {
        [BindProperty]
        public InputModel Input { get; set; }
        public class InputModel
        {
            public int Btqid { get; set; }
            public int Partenaireid { get; set; }
            public int Politiqueid { get; set; }

            [Required]
            [StringLength(100)]
            [Display(Name = "Description courte (100 caractères)")]
            public string BDescriptionC { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Description Longue (255 caractères)")]
            public string BDescriptionL { get; set; }
            [Required]
            [StringLength(255)]
            [Display(Name = "Raison Sociale")]
            public string Raisonsociale { get; set; }
            [Required]
            [StringLength(14,ErrorMessage ="Le numéro SIRET doit comporter 14 chiffres",MinimumLength =14)]
            [Display(Name = "Siret")]
            public string Siret { get; set; }
            [Required]
            [StringLength(9,ErrorMessage ="Le numéro SIREN doit comporter 9 chiffres",MinimumLength =9)]
            [Display(Name = "Siren")]
            public string Siren { get; set; }
            [Required]
            [StringLength(15)]
            [Display(Name = "Tel")]
            public string Btqtel { get; set; }
            [Required]
            [StringLength(14,ErrorMessage ="Le code NAF doit comporter 14 chiffres",MinimumLength =14)]
            [Display(Name = "Code NAF")]
            public string Codenaf { get; set; }
            [Required]
            [StringLength(5, ErrorMessage = "Le code Banque doit comporter 5 chiffres", MinimumLength = 5)]
            [Display(Name = "Code Banque")]
            public string Codebanque { get; set; }
            [Required]
            [StringLength(5, ErrorMessage = "Le code Guichet doit comporter 5 chiffres", MinimumLength = 5)]
            [Display(Name = "Code Guichet")]
            public string Codeguichet { get; set; }
            [Required]
            [StringLength(11, ErrorMessage = "Le Numéro de Compte doit comporter 11 chiffres", MinimumLength = 11)]
            [Display(Name = "Numéro de Compte")]
            public string Numcompte { get; set; }
            [Required]
            [StringLength(2, ErrorMessage = "La Clé RIB doit comporter 2 chiffres", MinimumLength = 2)]
            [Display(Name = "Clé RIB")]
            public string Clerib { get; set; }
            [Required]
            [StringLength(24, ErrorMessage = "La Domiciliation doit comporter 24 caratères", MinimumLength = 24)]
            [Display(Name = "Domiciliation")]
            public string Domiciliation { get; set; }
            [Required]
            [StringLength(27, ErrorMessage = "Le code IBAN doit comporter 27 chiffres", MinimumLength = 27)]
            [Display(Name = "IBAN")]
            public string Iban { get; set; }
            [Required]
            [StringLength(11, ErrorMessage = "Le code BIC doit comporter 11 chiffres", MinimumLength = 11)]
            [Display(Name = "BIC")]
            public string Bic { get; set; }
            [Required]
            [StringLength(140)]
            [Display(Name = "Titulaire")]
            public string Titulaire { get; set; }
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Btqtmail { get; set; }

            //public string Btqmessage { get; set; }
            public int? Ca { get; set; }
            public int? Nbsalarie { get; set; }
            public string Siteweb { get; set; }
            public string Statutjuridique { get; set; }
            [Required]
            [StringLength(100)]
            [Display(Name = "Mots Clé")]
            public string Btqseo { get; set; }
        }
    }
}
