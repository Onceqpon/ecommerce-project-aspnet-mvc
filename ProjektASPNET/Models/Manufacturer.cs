using ProjektASPNET.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace ProjektASPNET.Models
{
    public class Manufacturer : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Logo Producenta")]
        [Required(ErrorMessage = "Pole Logo Producenta jest wymagane.")]
        public string CompanyLogoURL { get; set; }

        [Display(Name = "Nazwa Producenta")]
        [Required(ErrorMessage = "Pole Nazwa Producenta jest wymagane.")]
        public string Name { get; set; }

        [Display(Name = "Opis Producenta")]
        [Required(ErrorMessage = "Pole Opis Producenta jest wymagane.")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
