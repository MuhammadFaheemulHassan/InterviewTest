using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetSevenCommerece.DataAccess.Repository.IRepository;
using NetSevenCommerece.Models;
using NetSevenCommerece.Utility;
using System.Data;

namespace NetSevenCommerece.Controllers
{
    [Authorize(Roles = Utilities.Rol_Cust)]
    public class TestCategoryController : Controller
    {
        private readonly ITestCategoryRespository _categoryRespository;
        public TestCategoryController(ITestCategoryRespository categoryRespository)
        {
            _categoryRespository = categoryRespository;
        }


        public IActionResult Index()
        {
            List<TestCategory> Categorylist = _categoryRespository.GetAll().ToList();
            return View(Categorylist);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(TestCategory category)
        {

            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Display Order can't be exatcly match with Name");
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
            if (id == null)
            {
                return NotFound();
            }
            TestCategory? category = _categoryRespository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        public IActionResult Edit(TestCategory category)
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
            TestCategory? category = _categoryRespository.Get(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            TestCategory? category = _categoryRespository.Get(c => c.Id == id);
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
