using ProjektASPNET.Data.Base;
using ProjektASPNET.Models;

namespace ProjektASPNET.Data.Services
{
    public interface IProductService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
    }
}
