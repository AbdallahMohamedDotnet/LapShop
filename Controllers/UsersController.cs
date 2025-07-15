using LapShopv2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LapShopv2.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public UsersController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        [HttpGet] 
        public IActionResult Login()
        {
            return View(new UserModel());
        }

        


        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserModel model)
        {
            if (!ModelState.IsValid)
                return View("Register", model);
            try {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.UserName = model.Email;
            var result = await _userManager.CreateAsync(user, model.Password);
            // the await keyword is used to asynchronously wait for the task to complete (make pause until the task is done)

            if (result.Succeeded)
                {
                    //var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password);
                    //if (loginResult.Succeeded)
                    //{
                    //    var myUser = await _userManager.FindByEmailAsync(user.Email);
                    //    await _userManager.AddToRoleAsync(myUser, "Customer");
                    //    return Redirect("/Order/OrderSuccess");
                    //}
                }
                else
                {
                    //foreach (var error in result.Errors)
                    //{
                    //    ModelState.AddModelError(string.Empty, error.Description);
                    //}
                    //return View(model);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Registration failed: " + ex.Message);
            }
            
            return View(model);
        }
    }
}
