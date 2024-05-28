using ECommerce.Enums.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Data
{
    public class AppDbInitializer
    {
        public static void seed(IApplicationBuilder builder)
        {
            using (var applicationservies = builder.ApplicationServices.CreateScope())
            {
                var context = applicationservies.ServiceProvider.GetService<EcommerceDbContext>();
                context.Database.EnsureCreated();
                //Category
                if(!context.Categories.Any())
                {
                    var categories = new List<Category>()
                    {
                        new Category()
                        {
                            Name="C1",
                            Description="C1",
                        },
                        new Category()
                        {
                            Name ="C2",
                            Description="C2",
                        },

                    };
                    context.Categories.AddRange(categories);
                    context.SaveChanges();
                }
                //Product
                if(!context.Products.Any())
                {
                    var products = new List<Product>()
                    {
                        new Product()
                        {
                            Pame="P1",
                            Description="P1",
                            Price=100,
                            ProductColor=ProductColor.Green,
                            ImageUrl="image/images.jpg",
                            CategoryId=1,
                        },
                        new Product()
                        {
                            Pame="P2",
                            Description="P2",
                            Price=200,
                            ProductColor=ProductColor.Red,
                            ImageUrl="image/imagestwo.jpg",
                            CategoryId=2,
                        },
                    };
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }
            }
        }
    }
}
