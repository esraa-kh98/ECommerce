﻿using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly EcommerceDbContext _context;
        public OrderServices(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrderAndRoleByUserIdAsync(string userId, string role)
        {
            var order= await _context.Orders.Include(x => x.OrderItems)
                 .ThenInclude(x => x.Product).Include(x => x.User)
                 .ToListAsync();
            if(role != "Admin")
            {
                order = order.Where(x => x.UserId == userId).ToList();
            }
            return order;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId)
        {
            var order = new Order()
            {
                UserId = userId
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            foreach(var item in items)
            {
                var orderitem = new OrderItem()
                {
                    Amount = item.Amount,
                    Price = item.Product.Price,
                    OrderId = order.Id,
                    ProductId = item.Product.Id
                };
                await _context.OrderItems.AddAsync(orderitem);
            }
            await _context.SaveChangesAsync();

        }
        public async Task CancelOrder(string userId,int orderId)
        {
            var order = _context.Orders.Include(x => x.OrderItems).FirstOrDefault
                (x => x.Id == orderId);
            if(order != null)
            {
                order.OrderStatus = Enums.OrderStatus.Canceled;
                await _context.SaveChangesAsync();
            }
        }
    }
}
