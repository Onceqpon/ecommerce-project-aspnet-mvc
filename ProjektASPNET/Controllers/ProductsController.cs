using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Data;
using ProjektASPNET.Data.Enums;
using ProjektASPNET.Models;

namespace ProjektASPNET.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var products = _context.Products
           .Include(p => p.Manufacturer)
           .OrderBy(p => p.Name)
           .ToList();

            return View(products);
        }

        public IActionResult IndexByCategory(ProductCategory? category)
        {
            int selectedCategoryValue = (int)(category ?? 0);

            var productsInSelectedCategory = _context.Products
                .Include(p => p.Manufacturer)
                .Where(p => (int)p.ProductCategory == selectedCategoryValue)
                .OrderBy(p => p.Name)
                .ToList();

            return View("Index", productsInSelectedCategory);
        }

        public IActionResult Search(IFormCollection formCollection)
        {
            string searchText = formCollection["search"];

            var productsMatchingSearch = _context.Products
                .Include(p => p.Manufacturer)
                .Where(p => p.Name.Contains(searchText) || p.Description.Contains(searchText)) // Szukaj fragmentu w polu Name lub Description
                .OrderBy(p => p.Name)
                .ToList();

            return View("Index", productsMatchingSearch);
        }

    }
}

