using System.ComponentModel.DataAnnotations;

namespace ProjektASPNET.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerIds{ get; set; }

        public string CompanyLogoURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Product> Products { get; set; }
    }
}
