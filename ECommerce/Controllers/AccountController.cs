using ECommerce.Data;
using ECommerce.Data.Static;
using ECommerce.Data.ViewModels;
using ECommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class AccountController : Controller
    {
        private readonly EcommerceDbContext _ecommerceDbContext;
        private readonly UserManager<ApplicationUser> _userManger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(EcommerceDbContext ecommerceDbContext, UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _ecommerceDbContext = ecommerceDbContext;
            _userManger = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Users()
        {
            var Response = await _ecommerceDbContext.Users.ToListAsync();
            return View(Response);
        }
        public IActionResult Login()
        {
            var Result = new loginVM();
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Login(loginVM model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = await _userManger.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                //Check Passsword
                var passwordCheck = await _userManger.CheckPasswordAsync(user,
                    model.Password);
                if (passwordCheck)
                {
                    var Result = await _signInManager.PasswordSignInAsync(user,
                       model.Password, false, false);
                    if (Result.Succeeded)
                    {
                        return RedirectToAction("Index", "Products");
                    }
                }
                return View(model);
            }
            return View(model);
        }
        public IActionResult Register()
        {
            var Result = new RegisterVM();
            return View(Result);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            var user = await _userManger.FindByEmailAsync(model.EmailAddress);
            if (user != null)
            {
                return View(model);
            }
            var newUser = new ApplicationUser()
            {
                Email = model.EmailAddress,
                FullName = model.FullName,
                UserName = model.EmailAddress.Split('@')[0]
            };
            var Result = await _userManger.CreateAsync(newUser,model.Password);
            if (Result.Succeeded)
            {
                await _userManger.AddToRoleAsync(newUser,UserRoles.User);
            }
            return View("CompleteRegister");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Products");
        }
    }
}
