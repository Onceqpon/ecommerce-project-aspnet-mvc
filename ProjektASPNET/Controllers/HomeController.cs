using FluentAssertions.Common;
using Microsoft.AspNetCore.Mvc;
using ProjektASPNET.Data.Services;
using ProjektASPNET.Models;
using System.Diagnostics;

namespace ProjektASPNET.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _service;

        public HomeController(IProductService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var AllProduct = await _service.GetAllAsync();

            return View(AllProduct);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}