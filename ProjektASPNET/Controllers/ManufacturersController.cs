using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Data;
using ProjektASPNET.Data.Services;
using ProjektASPNET.Data.ViewModel;
using ProjektASPNET.Models;

namespace ProjektASPNET.Controllers
{
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerService _service;
        private readonly AppDbContext _context;

        public ManufacturersController(IManufacturerService service, AppDbContext context)
        {   
            _service = service;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var manufaturer = await _service.GetByIdAsync(id);
            return View(manufaturer);
        }
        [Authorize("Admin")]
        public IActionResult Create()
        {
            return View();
        }
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Create(Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(manufacturer);
                return RedirectToAction(nameof(Index));
            }
            return View(manufacturer);
        }
        [Authorize("Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewManufacturerVM()
            {
                Id = manufacturerDetails.Id,
                CompanyLogoURL = manufacturerDetails.CompanyLogoURL,
                Name = manufacturerDetails.Name,
                Description = manufacturerDetails.Description,
                
            };


            return View(response);
        }
        [Authorize("Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewManufacturerVM manufacturerVM)
        {
            if (id != manufacturerVM.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                return View(manufacturerVM);
            }

            await _service.UpdateManufaturerAsync(manufacturerVM);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Delete(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return View("_DeleteConfirmation", id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturer = await _context.Manufacturers.FindAsync(id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
