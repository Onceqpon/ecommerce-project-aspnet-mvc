using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Data.Base;
using ProjektASPNET.Data.ViewModel;
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

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                ShortDescription = data.ShortDescription,
                ImageURL = data.ImageURL,
                ManufacturerId = data.ManufacturerId,
                ReleaseYear = data.ReleaseYear,
                AvaibleParts = data.AvaibleParts,
                Price = data.Price,
                ProductCategory = data.ProductCategory,

            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();


        }

        public async Task<ProductDropdownsVM> GetNewMovieDropdonsValue()
        {
            var response = new ProductDropdownsVM();
            response.Manufacturers = await _context.Manufacturers.OrderBy(x => x.Name).ToListAsync();
            return response;

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
