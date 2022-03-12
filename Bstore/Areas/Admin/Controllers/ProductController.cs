using Bstore.DataAccess.Data;
using Bstore.DataAccess.Repository.IRepository;
using Bstore.Models;
using Bstore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learningweb.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> categoryobj = _unitOfWork.Product.GetAll();
            return View(categoryobj);
        }

      
        public IActionResult InsetUpdate(int? id)
        {
            ProductVM ProductVM = new()
            {
                Product = new Product(),
                CategoryList = (IEnumerator<SelectListItem>)_unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                CovereTypeList = (IEnumerator<SelectListItem>)_unitOfWork.CoverType.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                })

            };

            if (id == 0 || id == null)
            {
                //ViewBag.Catagoty = CategoryList; // view bag method
                //ViewData["CovereType"] = CovereType;//view data method
                return View(ProductVM);
            }
            else
            {
              
            }



            return View(ProductVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsetUpdate(ProductVM obj,IFormFile file)
        {

            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Same name can not used");
            //}
            //if (ModelState.IsValid)
            //{


                //_unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category Edit has been added";
                return RedirectToAction("Index");
            //}
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var objresult = _unitOfWork.Category.GetFirstOrDefault(x => x.Id == id);
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
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "Category has been Deleted";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
