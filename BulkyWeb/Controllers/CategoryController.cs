using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categoriesList =  _db.Categories.ToList();
            return View(categoriesList);
        }
        // creat new action 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name==obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Name", "The Name cannot be similar to display order");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Sucessfully created";
                // sau đso qua trong list, action index
                // khác controller
                //return RedirectToAction("action","controller")
                //cùng controller, ko cần khai báo contreoller
                return RedirectToAction("Index");
            }

            return View();

        }
        public IActionResult Edit(int? ID)
        {
            if(ID == null || ID == 0)
            {
                return NotFound();  
            }
            Category category = _db.Categories.Find(ID); // only use for pk
            // we have three ways to find in database 
            Category? category1 = _db.Categories.FirstOrDefault(x => x.CategoryId == ID);
            Category? category2 = _db.Categories.Where(x=>x.CategoryId == ID).FirstOrDefault();
            if (category == null)
            {
                return NotFound(); 
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Sucessfully edited";
                // sau đso qua trong list, action index
                // khác controller
                //return RedirectToAction("action","controller")
                //cùng controller, ko cần khai báo contreoller
                return RedirectToAction("Index");
            }

            return View();

        }
        // vì ai action có tên và param truyền vào gióng nhua nên asp sẽ khoogn phân biệt được đâu là action đúng, nên hai tên của 2 action phải khsc nhau
        public IActionResult Delete(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            Category category = _db.Categories.Find(ID); // only use for pk
            // we have three ways to find in database 
            Category? category1 = _db.Categories.FirstOrDefault(x => x.CategoryId == ID);
            Category? category2 = _db.Categories.Where(x => x.CategoryId == ID).FirstOrDefault();
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        // phải có action name, để khi chạy action DELETE POST, url của nó sẽ có dạng: /delete/id
        // một url có nhiều method
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Sucessfully deleted";
            return RedirectToAction("index");
        }
    }
}
