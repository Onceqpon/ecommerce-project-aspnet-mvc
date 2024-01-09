using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektASPNET.Data;
using ProjektASPNET.Data.Enums;
using ProjektASPNET.Data.Services;
using ProjektASPNET.Data.ViewModel;
using ProjektASPNET.Models;

namespace ProjektASPNET.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var AllProduct = await _service.GetAllAsync(n => n.Manufacturer);

            return View(AllProduct);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var movieDetail = await _service.GetProductByIdAsync(id);
            return View(movieDetail);
        }

        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetNewMovieDropdonsValue();
            ViewBag.Manufacturers = new SelectList(productDropdownsData.Manufacturers, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if(!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewMovieDropdonsValue();
                ViewBag.Manufacturers = new SelectList(productDropdownsData.Manufacturers, "Id", "Name");
                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction("Index");
        }
        public IActionResult IndexByCategory(ProductCategory? category)
        {

            return View("Index");
        }

        public IActionResult Search(IFormCollection formCollection)
        {
           

            return View("Index");
        }

    }
}

