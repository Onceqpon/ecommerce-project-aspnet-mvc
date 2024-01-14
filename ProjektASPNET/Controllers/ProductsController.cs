using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if(productDetails ==  null) 
            {
                return View("NotFound");
            }

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Description = productDetails.Description,
                ShortDescription = productDetails.ShortDescription,
                ImageURL = productDetails.ImageURL,
                ReleaseYear = productDetails.ReleaseYear,
                ManufacturerId = productDetails.ManufacturerId,
                Price = productDetails.Price,
                AvaibleParts = productDetails.AvaibleParts,
            };

            var productDropdownsData = await _service.GetNewMovieDropdonsValue();
            ViewBag.Manufacturers = new SelectList(productDropdownsData.Manufacturers, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {

            if(id != product.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetNewMovieDropdonsValue();
                ViewBag.Manufacturers = new SelectList(productDropdownsData.Manufacturers, "Id", "Name");
                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> IndexByCategory(ProductCategory category)
        {
            var AllProduct = await _service.GetAllAsync(n => n.Manufacturer);
            
            var categoryResult = AllProduct.Where(n => n.ProductCategory == category).ToList();
            
            return View("Index", categoryResult);
        }

        public async Task<IActionResult> Filter(string searchString)
        {

            var AllProduct = await _service.GetAllAsync(n => n.Manufacturer);

            if(!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = AllProduct.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", AllProduct);
        }

    }
}

