using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ProductManagementSystem.Models;
using ProductManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace EmpManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(SignInManager<User> _signin, UserManager<User> _user, RoleManager<IdentityRole> _role)
        {
            signInManager = _signin;
            userManager = _user;
            roleManager = _role;
        }
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("DisplayAll", "Product");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, loginViewModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("DisplayAll", "Product");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                ProductManagementSystem.Models.User newuser = new User()
                {
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                    UserName = registerViewModel.UserName,
                    PhoneNumber = registerViewModel.PhoneNumber.ToString(),
                    Email = registerViewModel.Email
                };
                var result = await userManager.CreateAsync(newuser, registerViewModel.Password);
                if (result.Succeeded)
                {
                    var addedUser = await userManager.FindByNameAsync(newuser.UserName);
                    if (addedUser.UserName == "Admin")
                    {
                        await userManager.AddToRoleAsync(addedUser, "Admin");
                        await userManager.AddToRoleAsync(addedUser, "Employee");
                    }
                    else
                    {
                        await userManager.AddToRoleAsync(addedUser, "Employee");
                    }
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();


        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
