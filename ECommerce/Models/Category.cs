using ECommerce.Data.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Category :IBaseEntity
    {
        public Category()
            {
             Products= new HashSet<Product>();
            }
        [Key]
        public int Id { set; get; }

        [Required(ErrorMessage ="Name Is Required")]
        [StringLength(10,ErrorMessage ="This {0} Is Spesific Between {2},{1}",MinimumLength =5)]
        [Display(Name = "Category Name")]
        public string Name { set; get; }

        [Required(ErrorMessage ="Description Is Resquired")]
        public string Description { set; get; }

        //Navigational Popery
        public ICollection<Product> Products { set; get; }

    }
}
