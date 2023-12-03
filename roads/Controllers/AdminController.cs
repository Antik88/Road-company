using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using roads.Data;
using roads.Models;

namespace roads.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AdminController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateProject()
        {
            return View();
        }
        public async Task<IActionResult> OrderMaterial()
        {
            IEnumerable<OrderMaterial> orderMaterials = await _appDbContext.OrderMaterials
                .Include(m => m.Material)
                .ToListAsync();

            return View(orderMaterials);
        }
    }
}
