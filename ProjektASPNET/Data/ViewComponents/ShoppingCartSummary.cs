using Microsoft.AspNetCore.Mvc;
using ProjektASPNET.Data.Cart;

namespace ProjektASPNET.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var item = _shoppingCart.GetShoppingCartItems();
            return View(item.Count);
        }
    }
}
