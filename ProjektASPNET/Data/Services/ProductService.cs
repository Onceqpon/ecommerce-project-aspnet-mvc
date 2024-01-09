using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Data.Base;
using ProjektASPNET.Models;

namespace ProjektASPNET.Data.Services
{
    public class ProductService:EntityBaseRepository<Product>, IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(c => c.Manufacturer)
                .FirstOrDefaultAsync(n => n.Id == id);
            
            return productDetails;
        }
    }
}
