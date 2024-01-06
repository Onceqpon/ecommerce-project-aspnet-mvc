using ProjektASPNET.Data.Base;
using ProjektASPNET.Models;

namespace ProjektASPNET.Data.Services
{
    public class ManufacturerService:EntityBaseRepository<Manufacturer>, IManufacturerService
    {
        public ManufacturerService(AppDbContext context) : base(context) { }
    }
}
