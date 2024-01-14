using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Data.Base;
using ProjektASPNET.Data.ViewModel;
using ProjektASPNET.Models;

namespace ProjektASPNET.Data.Services
{
    public class ManufacturerService:EntityBaseRepository<Manufacturer>, IManufacturerService
    {
        private readonly AppDbContext _context;
        public ManufacturerService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task UpdateManufaturerAsync(NewManufacturerVM data)
        {

            var dbManufacturer = await _context.Manufacturers.AsTracking().FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbManufacturer != null)
            {
                dbManufacturer.Name = data.Name;
                dbManufacturer.Description = data.Description;
                dbManufacturer.CompanyLogoURL = data.CompanyLogoURL;
                

                await _context.SaveChangesAsync();
            }
        }



    }
}
