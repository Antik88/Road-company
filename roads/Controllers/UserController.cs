using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using roads.Data;
using roads.Interfaces;
using roads.Models;

namespace roads.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(AppDbContext appDbContext, IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<User> users = await _userRepository.GetAll(); 
            return View(users);
        }

        public async Task<IActionResult> Details(User user)
        {
            return View(user);
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginUser(User user)
        {
            var authenticatedUser = await _userRepository.CheckCredentials(user.Login, user.Password);

            if (authenticatedUser != null)
            {
                ViewBag.Role = authenticatedUser.Role;
                return RedirectToAction("Details", authenticatedUser);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Неверный логин или пароль");
                return View();
            }
        }
        public async Task<IActionResult> LogOut()
        {
            return View();
        }
    }
}
