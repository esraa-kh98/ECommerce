using ECommerce.Data.Static;
using ECommerce.Enums.Data;
using ECommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder builder)
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
                            Name="P1",
                            Description="P1",
                            Price=100,
                            ProductColor=ProductColor.Green,
                            ImageUrl="image/images.jpg",
                            CategoryId=1,
                        },
                        new Product()
                        {
                            Name="P2",
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
        public static async Task SeedUserAndRolesAsync(IApplicationBuilder builder)
        {
            using (var applicationservies = builder.ApplicationServices.CreateScope())
            {
                #region Role
                var roleManger =
                    applicationservies.ServiceProvider.GetRequiredService<RoleManager
                    <IdentityRole>>();
                if(! await roleManger.RoleExistsAsync(UserRoles.Admin))
                {
                    await roleManger.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                if(! await roleManger.RoleExistsAsync(UserRoles.User))
                {
                    await roleManger.CreateAsync(new IdentityRole(UserRoles.User));
                }
                #endregion
                #region User
                var userManger =
                    applicationservies.ServiceProvider.GetRequiredService<UserManager
                    <ApplicationUser>>();
                if(await userManger.FindByEmailAsync("admin@admin.com") == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Email = "admin@admin.com",
                        EmailConfirmed = true,
                        FullName = "Admin User",
                        UserName = "Admin"
                    };
                    await userManger.CreateAsync(newAdminUser, "@Admin123");
                    await userManger.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                if(await userManger.FindByEmailAsync("user@user.com") == null)
                {
                    var newOridinalUser = new ApplicationUser()
                    {
                        Email="user@user.ccom",
                        EmailConfirmed=true,
                        FullName="Oridinal User",
                        UserName="User"
                    };
                    await userManger.CreateAsync(newOridinalUser, "@User123");
                    await userManger.AddToRoleAsync(newOridinalUser,UserRoles.User);
                }
                #endregion

            }
        }
    } 
}
