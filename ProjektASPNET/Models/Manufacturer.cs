using System.ComponentModel.DataAnnotations;

namespace ProjektASPNET.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerIds{ get; set; }

        [Display(Name = "Logo Producenta")]
        public string CompanyLogoURL { get; set; }
        [Display(Name = "Nazwa Producenta")]
        public string Name { get; set; }
        [Display(Name = "Opis Producenta")]
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
