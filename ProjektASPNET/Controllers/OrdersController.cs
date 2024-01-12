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

        public OrdersController(IProductService productService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _productService = productService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<ActionResult> Index()
        {
            var orders = await _ordersService.GetOrdersByUserIdAsync("");
            return View(orders);
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
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return View("OrderCompleted");

        }
    }
}
