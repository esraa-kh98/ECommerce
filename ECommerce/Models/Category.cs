using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Category
    {
        public Category()
            {
             Products= new HashSet<Product>();
            }
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }

        //Navigational Popery
        public ICollection<Product> Products { set; get; }

    }
}
