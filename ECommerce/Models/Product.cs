using ECommerce.Enums.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        [Key]
        public int Id { set; get; }
        public string Pame { set; get; }
        public string Description { set; get; }
        public double Price { set; get; }
        public string ImageUrl { set; get; }
        public ProductColor ProductColor { set; get; }

        public int CategoryId { set; get; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { set; get; }
    }
}
