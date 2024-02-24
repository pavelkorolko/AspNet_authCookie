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
        private readonly ArticleRepository articleRepository;

        public HomeController(UserRepository userRepository, ArticleRepository articleRepository)
        {
            this.userRepository = userRepository;
            this.articleRepository = articleRepository;
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
                        var claims = new List<Claim> { new Claim(ClaimTypes.Email, currentUser.Email),
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
            var currentId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var currentUser = userRepository.GetUserById(int.Parse(currentId));

            return View(currentUser);
        }

        public IActionResult Main()
        {
            var allArticles = articleRepository.Articles;
            return View(allArticles);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Main));
        }

        [Authorize]
        public IActionResult Data(int id)
        {
            var currentUser = userRepository.GetUserById(id);
            return View(currentUser);
        }
        [Authorize]
        public IActionResult Article(int id)
        {
            var current = articleRepository.GetArticleById(id);
            return View(current);
        }
        [Authorize]
        [HttpPost]
        public IActionResult Article(Article article)
        {
            articleRepository.Update(article);
            TempData["UserChanged"] = true;
            return RedirectToAction(nameof(Article));
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Data(User user, int id)
        {
            if (ModelState.IsValid)
            {
                var currentUser = userRepository.Users.FirstOrDefault(e => e.Id == id);
                userRepository.UpdateUser(user, id);
                TempData["UserChanged"] = true;

                var claims = new List<Claim> { new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.NameIdentifier, id.ToString())};
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                return RedirectToAction(nameof(Data));
            }
            else
            {
                return View(user);
            }
        }
        [Authorize]
        public IActionResult Articles()
        {
            var currentId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var currentUserArticles = articleRepository.Articles.Where(e => e.UserId == int.Parse(currentId!)).ToList();

            return View(currentUserArticles);

        }
        [Authorize]
        public IActionResult AddArticle()
        {
            var currentId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            int id = articleRepository.Articles.Count;

            var current = new Article { Id = ++id, UserId = int.Parse(currentId)};
            return View(current);
        }
        [Authorize]
        [HttpPost]
        public IActionResult AddArticle(Article article, int id, int userId)
        {
            article.UserId = userId;
            article.Id = id;
            articleRepository.AddArticle(article);

            return RedirectToAction(nameof(Admin));
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            articleRepository.Delete(id);
            return RedirectToAction(nameof(Articles));
        }
    }
}
