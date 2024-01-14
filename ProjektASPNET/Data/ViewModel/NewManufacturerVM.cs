using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using ProjektASPNET.Models;
using System.ComponentModel.DataAnnotations;

namespace ProjektASPNET.Data.ViewModel
{
    public class NewManufacturerVM
    {
        public int Id { get; set; }
        [Display(Name = "Logo Producenta")]
        [Required(ErrorMessage = "Pole Logo Producenta jest wymagane.")]
        [RegularExpression(@"^(http|https)://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$", ErrorMessage = "Pole Logo Producenta musi być poprawnym URL-em HTTP lub HTTPS.")]
        public string CompanyLogoURL { get; set; }


        [Display(Name = "Nazwa Producenta")]
        [Required(ErrorMessage = "Pole Nazwa Producenta jest wymagane.")]
        public string Name { get; set; }

        [Display(Name = "Opis Producenta")]
        [Required(ErrorMessage = "Pole Opis Producenta jest wymagane.")]
        public string Description { get; set; }
    }
}
