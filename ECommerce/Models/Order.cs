using ECommerce.Data.Base;
using System.Collections.Generic;

namespace ECommerce.Models
{
    public class Order : IBaseEntity
    {
        public Order()
            {
             var orderItems = new HashSet<OrderItem>();
            }
        [key]
        public int Id { get ; set; }
        public string UserId { get; set; }

        public ICollection<OrderItem> OrderItems { set; get; }
    }
}
