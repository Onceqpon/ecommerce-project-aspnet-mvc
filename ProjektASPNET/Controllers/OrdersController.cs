using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjektASPNET.Data.Cart;
using ProjektASPNET.Data.Services;
using ProjektASPNET.Data.ViewModel;

namespace ProjektASPNET.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IProductService _productService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrdersService _ordersService;
        private readonly UserManager<IdentityUser> _userManager;

        public OrdersController(IProductService productService, ShoppingCart shoppingCart, IOrdersService ordersService, UserManager<IdentityUser> userManager)
        {
            _productService = productService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
            _userManager = userManager;
        }

        public async Task<ActionResult> Index()
        {

            if (User.IsInRole("Admin"))
            {
                var allOrders = await _ordersService.GetAllOrdersAsync();
                return View(allOrders);
            }
            else if (User.IsInRole("User"))
            {
                string userId = _userManager.GetUserId(User);
                var orders = await _ordersService.GetOrdersByUserIdAsync(userId);
                var user = await _userManager.FindByIdAsync(userId);
                string userEmailAddress = user.Email;
                return View(orders);
            }

            return View();
        }

        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
            };
            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _productService.GetProductByIdAsync(id);

            if(item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> RemoveToShoppingCart(int id)
        {
            var item = await _productService.GetProductByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFormCart(item);
            }
            return RedirectToAction("ShoppingCart");
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = _userManager.GetUserId(User); // Pobierz ID użytkownika

            // Użyj UserManager do wczytania pełnych informacji o użytkowniku na podstawie jego ID
            var user = await _userManager.FindByIdAsync(userId);

            // Teraz masz dostęp do pełnych informacji o użytkowniku, takich jak jego właściwości profilowe
            string userEmailAddress = user.Email; // Przykład użycia, aby pobrać adres e-mail użytkownika

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");
        }
    }
}
