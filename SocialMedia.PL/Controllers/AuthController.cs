using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.BLL.ModelVM.ApplicationUserVM;
using SocialMedia.DAL.Database;
using SocialMedia.DAL.Entites;
using System.Security.Claims;

namespace SocialMedia.PL.Controllers
{
    public class AuthController : Controller
    {
        private readonly SocialMediaDbContext db;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AuthController(SocialMediaDbContext db , UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) 
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM userVM)
        {
            if(!ModelState.IsValid)
            {
                return View("Register", userVM);
            }
            ApplicationUser user = new ApplicationUser()
            {
                UserName = string.IsNullOrWhiteSpace(userVM.Name) ? userVM.Email : userVM.Name.Replace(" ", ""),
                Email = userVM.Email,
                PhoneNumber = userVM.PhoneNumber,
                Address = userVM.Address,
            };

            var identityResult = await userManager.CreateAsync(user, userVM.Password);
            if(!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("Register", userVM);
            }
            
            await signInManager.SignInAsync(user, false);
            return RedirectToAction("GetAll", "Employee");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await userManager.FindByEmailAsync(loginVM.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(loginVM);
            }

            var result = await signInManager.PasswordSignInAsync(
                user.UserName!,
                loginVM.Password,
                loginVM.RememberMe,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                return RedirectToAction("GetAll", "Employee");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(loginVM);
        }

        
    }
}
