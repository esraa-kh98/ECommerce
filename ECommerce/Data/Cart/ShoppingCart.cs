using ECommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Cart
{
    public class ShoppingCart
    {
        private readonly EcommerceDbContext _context;
        public string ShoppingCartId { set; get; }
        public ShoppingCart(EcommerceDbContext context)
        {
            _context = context;
        }
        public static ShoppingCart GetShoppingCart(IServiceProvider service)
        {
            var session = service.GetRequiredService<IHttpContextAccessor>().HttpContext.Session;
            var context = service.GetRequiredService<EcommerceDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public  List<ShoppingCartItem> GetShoppingCartItems()
        {
            return _context.shoppingCartItems.Where(x =>
            x.shoppingCartId == ShoppingCartId).Include(x => x.Product).ToList();
        }
        public int GetShoppingCartTotalAmount()
        {
            return _context.shoppingCartItems.Where(x => x.shoppingCartId == ShoppingCartId)
                .Select(x => x.Amount).Sum();

        }
        public double GetShoppingCartTotal()
        {
            var total = _context.shoppingCartItems.Where(x =>
              x.shoppingCartId == ShoppingCartId).Select(x =>
                x.Product.Price * x.Amount).Sum();
            return total;
        }
        public async Task AddItemToShoppingCart(Product product)
        {
            var shoppingCartItem =await _context.shoppingCartItems.FirstOrDefaultAsync(x =>
              x.shoppingCartId == ShoppingCartId && x.Product.Id == product.Id);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    shoppingCartId = ShoppingCartId,
                    Product = product,
                    Amount = 1
                };
                await _context.shoppingCartItems.AddAsync(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount += 1;
            }
            await _context.SaveChangesAsync();
        }
        public async Task RemoveItemFromShopping(Product product)
        {
            var shoppingCartItem = await _context.shoppingCartItems.FirstOrDefaultAsync(x =>
               x.shoppingCartId == ShoppingCartId && x.Product.Id == product.Id);
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount -= 1;
                }
                else
                {
                    _context.shoppingCartItems.Remove(shoppingCartItem);
                }
                await _context.SaveChangesAsync();
            }
        }
        public void ClearShoppingCart()
        {
            var items = _context.shoppingCartItems.Where(x => x.shoppingCartId ==
              ShoppingCartId).ToList();
            _context.shoppingCartItems.RemoveRange(items);
            _context.SaveChanges();
        }

    }
}
