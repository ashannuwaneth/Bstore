using Bstore.DataAccess.Data;
using Bstore.DataAccess.Repository.IRepository;
using Bstore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learningweb.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> categoryobj = _db.GetAll();
            return View(categoryobj);
        }

        //Get
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","Same name can not used");
            }
            if(ModelState.IsValid)
            {

                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Category has been added";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var objresult = _db.GetFirstOrDefault(x => x.Id == id);
            if (objresult == null)
            {
                return NotFound();
            }


            return View(objresult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Same name can not used");
            }
            if (ModelState.IsValid)
            {

       
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Category Edit has been added";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var objresult = _db.GetFirstOrDefault(x => x.Id == id);
            if (objresult == null)
            {
                return NotFound();
            }


            return View(objresult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {

            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "Same name can not used");
            }
            if (ModelState.IsValid)
            {
                _db.Remove(obj);
                _db.Save();
                TempData["success"] = "Category has been Deleted";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
