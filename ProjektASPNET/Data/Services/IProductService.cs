using ProjektASPNET.Data.Base;
using ProjektASPNET.Data.ViewModel;
using ProjektASPNET.Models;

namespace ProjektASPNET.Data.Services
{
    public interface IProductService:IEntityBaseRepository<Product>
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<ProductDropdownsVM> GetNewMovieDropdonsValue();
        Task AddNewProductAsync(NewProductVM data);
        Task UpdateProductAsync(NewProductVM data);
    }
}
