using ECommerce.Data.Cart;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerce.Data.ViewComponents
{
    public class ShoppingCartSummary :ViewComponent
    {
        private readonly ShoppingCart _cart;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ShoppingCartSummary(ShoppingCart cart, IHttpContextAccessor httpContextAccessor)
        {
            _cart = cart;
            _httpContextAccessor = httpContextAccessor;
        }
        public IViewComponentResult Invoke()
        {
            string userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var item = _cart.GetShoppingCartTotalAmount(userId);
            ViewBag.Total = _cart.GetShoppingCartTotal(userId);
            return View(item);
        }
    }
}
