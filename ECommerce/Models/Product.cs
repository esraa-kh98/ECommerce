using ECommerce.Data.Base;
using ECommerce.Enums.Data;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product :IBaseEntity
    {
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage = "Name Is Required")]
        [Display(Name = "Product Name")]
        public string Name { set; get; }

        [Required(ErrorMessage = "Description Is Required")]
        public string Description { set; get; }

        [Required(ErrorMessage = "Price Is Required")]
        public double Price { set; get; }
        public string ImageUrl { set; get; }
        [NotMapped]
        public IFormFile ProductPicture { get; set; }
        public ProductColor ProductColor { set; get; }

        public int CategoryId { set; get; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { set; get; }
    }
}
