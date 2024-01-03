using Microsoft.AspNetCore.Mvc;
using ProjektASPNET.Data;

namespace ProjektASPNET.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly AppDbContext _context;

        public ManufacturersController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var data = _context.Manufacturers.ToList();
            return View(data);
        }
    }
}
