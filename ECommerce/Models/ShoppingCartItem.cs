using ECommerce.Data.Base;

namespace ECommerce.Models
{
    public class ShoppingCartItem : IBaseEntity
    {
        public int Id { get ; set ; }
        public int Amount { set; get; }
        public Product Product { set; get; }
        public string shoppingCartId { set; get; } 

    }
}
