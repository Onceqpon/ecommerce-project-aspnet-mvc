using Microsoft.AspNetCore.Mvc;
using ProjektASPNET.Data;
using ProjektASPNET.Data.Services;
using ProjektASPNET.Models;

namespace ProjektASPNET.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService _service;

        public ManufacturersController(IManufacturerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("CompanyLogoURL,Name,Description")]Manufacturer manufacturer)
        {
            if (!ModelState.IsValid) return View(manufacturer);
            await _service.AddAsync(manufacturer);
            return RedirectToAction(nameof(Index));
        }
    }
}
