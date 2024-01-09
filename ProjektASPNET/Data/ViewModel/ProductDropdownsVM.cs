using ProjektASPNET.Models;

namespace ProjektASPNET.Data.ViewModel
{
    public class ProductDropdownsVM
    {
        public ProductDropdownsVM()
        {
            Manufacturers = new List<Manufacturer>();
        }
        public List<Manufacturer> Manufacturers { get; set; }
    }
}
