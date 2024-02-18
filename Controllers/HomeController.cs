using Classwork_16._02._24_auth_authorization__2.Models;
using Classwork_16._02._24_auth_authorization__2.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Classwork_16._02._24_auth_authorization__2.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository userRepository;

        public HomeController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Login()
        {
            if (User.Identity!.IsAuthenticated)
            {
                return RedirectToAction(nameof(Admin));
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var currentUser = userRepository.Users.FirstOrDefault(e => e.Email.Equals(user.Email));
                if (currentUser != null)
                {
                    if (currentUser.Password.Equals(user.Password))
                    {
                        var claims = new List<Claim> { new Claim(ClaimTypes.Name, currentUser.Email),
                            new Claim(ClaimTypes.NameIdentifier, currentUser.Id.ToString())};
                        ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                        return RedirectToAction(nameof(Admin));
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Wrong password.");
                    }
                }
                ModelState.AddModelError("Email", "Can`t find this email address!");
                return View(user);
            }
            else
            {
                return View(user);
            }
        }
        [Authorize]
        public IActionResult Admin()
        {
            return View();
        }

        public IActionResult Main()
        {
            var allArticles = userRepository.Articles;
            
            return View(allArticles);
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }
    }
}
