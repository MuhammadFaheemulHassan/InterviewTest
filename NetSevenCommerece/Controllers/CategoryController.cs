using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetSevenCommerece.Models;
using NetSevenCommerece.DataAccess.Data;
using NetSevenCommerece.DataAccess.Repository.IRepository;
using NetSevenCommerece.DataAccess.Repository;
using Microsoft.AspNetCore.Authorization;
using NetSevenCommerece.Utility;

namespace NetSevenCommerece.Controllers
{
    [Authorize(Roles =Utilities.Rol_Admin)]
    public class CategoryController : Controller
    {
        private readonly ICategoryRespository _categoryRespository;
        public CategoryController(ICategoryRespository categoryRespository)
        {
            _categoryRespository = categoryRespository;
        }

       
        public IActionResult Index()
        {
            List<Category> Categorylist = _categoryRespository.GetAll().ToList();
            return View(Categorylist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
           
                if (category.Name == category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Display Order can't be exatcly match with Name");
                }
                if (category.Name.ToLower() == "test")
                {
                    ModelState.AddModelError("", "Display Order can't be exatcly match with Name");
                }
                if (ModelState.IsValid)
                {
                _categoryRespository.Add(category);
                _categoryRespository.Save();
                TempData["msg"] = "Record has been added successfully";
                    return RedirectToAction("Index");
                }
           
            
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if(id== null)
            {
                return NotFound();
            }
            Category? category = _categoryRespository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRespository.Update(category);
                _categoryRespository.Save();
                TempData["msg"] = "Record has been updated successfully";
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
            Category? category = _categoryRespository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? category = _categoryRespository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _categoryRespository.Remove(category);
                _categoryRespository.Save();
                TempData["msg"] = "Record has been deleted successfully";
                return RedirectToAction("Index");
            }


            return View();

        }
    }
}
