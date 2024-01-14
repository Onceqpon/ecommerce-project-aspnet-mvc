using ProjektASPNET.Data.Base;
using ProjektASPNET.Data.ViewModel;
using ProjektASPNET.Models;

namespace ProjektASPNET.Data.Services
{
    public interface IManufacturerService:IEntityBaseRepository<Manufacturer>
    {
        Task UpdateManufaturerAsync(NewManufacturerVM data);
    }
}
