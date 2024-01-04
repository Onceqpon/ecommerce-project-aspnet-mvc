using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Data;
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
        public async Task<IActionResult> Index()
        {
            var products = _context.Products
           .Include(p => p.Manufacturer) // Wczytaj producenta, jeśli jest to wymagane
           .ToList();

            return View(products);
        }
    }
}

