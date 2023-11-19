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

        public async Task<IActionResult> Details(int id)
        {
            User user = await _userRepository.GetByIdAsync(id);
            return View(user);
        }
    }
}
