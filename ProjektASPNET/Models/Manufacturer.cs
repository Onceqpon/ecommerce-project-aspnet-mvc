using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ProjektASPNET.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektASPNET.Models
{
    public class Manufacturer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [BindProperty]
        [Display(Name = "Logo Producenta")]
        [Required(ErrorMessage = "Pole Logo Producenta jest wymagane.")]
        [RegularExpression(@"^(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$", ErrorMessage = "Pole Logo Producenta musi być poprawnym URL-em HTTP lub HTTPS.")]
        public string CompanyLogoURL { get; set; }

        [BindProperty]
        [Display(Name = "Nazwa Producenta")]
        [Required(ErrorMessage = "Pole Nazwa Producenta jest wymagane.")]
        public string Name { get; set; }

        [BindProperty]
        [Display(Name = "Opis Producenta")]
        [Required(ErrorMessage = "Pole Opis Producenta jest wymagane.")]
        public string Description { get; set; }

        [ValidateNever]
        public List<Product> Products { get; set; }

    }
}
