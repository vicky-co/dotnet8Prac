using BulkyWebApp.Data;
using BulkyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWebApp.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext db;
        public CategoryController(ApplicationDbContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            List<Category> categories = db.Categories.ToList();
            return View(categories);
        }
    }
}
