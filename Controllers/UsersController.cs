using LapShopv2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LapShopv2.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
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

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(user, model.Password, true, true);
                    var myUser = await _userManager.FindByEmailAsync(user.Email);
                    await _userManager.AddToRoleAsync(myUser, "Admin");
                    if (loginResult.Succeeded)
                        Redirect("/Order/OrderSuccess");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {

            }
            return View(new UserModel());
        }
    }
}