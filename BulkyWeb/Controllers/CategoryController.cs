using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }





        //edit action methods
        //GET
        public IActionResult Edit(int? id)
        {
            //testing if the id is null to return not found 
            //can create an error page and redirect to it

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromDb = _categoryRepo.Get(u => u.Id == id);
            //Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? CategoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //Edit Action Methods 
        //POST (I guess)
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }



        //Delete action methods
        //GET
        public IActionResult Delete(int? id)
        {
            //testing if the id is null to return not found 
            //can create an error page and redirect to it

            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? CategoryFromDb = _categoryRepo.Get(u => u.Id == id);
            //Category? CategoryFromDb1 = _db.Categories.FirstOrDefault(u => u.Id == id);
            //Category? CategoryFromDb2 = _db.Categories.Where(u => u.Id == id).FirstOrDefault();

            if (CategoryFromDb == null)
            {
                return NotFound();
            }
            return View(CategoryFromDb);
        }
        //Edit Action Methods 
        //POST (I guess)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}
