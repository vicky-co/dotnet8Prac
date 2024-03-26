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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category.Name == "test")
            {
                ModelState.AddModelError("Name", "Category Name Cannot be test");
            }
            Category? existCategory = db.Categories.FirstOrDefault(c => c.Name == category.Name && c.DisplayOrder == category.DisplayOrder);
            if (existCategory!= null)
            {
                ModelState.AddModelError("", "Entry Already Exist");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                TempData["Success"] = "Category Created Successfully.";
                return RedirectToAction("Index");
            } 
            return View();
        }        
        public IActionResult Edit(int? catId)
        {
            if(catId == null)
            {
                return NotFound();
            }
            Category? category = db.Categories.FirstOrDefault(c => c.Id == catId);
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if(category.Name == "test")
            {
                ModelState.AddModelError("Name","Category Name Cannot be test");
            }
            Category? existCategory = db.Categories.FirstOrDefault(c => c.Name == category.Name && c.DisplayOrder == category.DisplayOrder);
            if (existCategory != null)
            {
                ModelState.AddModelError("", "Entry Already Exist");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Update(category);
                db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Category? category = db.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? category = db.Categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            db.Categories.Remove(category);
            db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully.";
            return RedirectToAction("Index");
            /*return View("Index","Category");*/
        }
    }
}
