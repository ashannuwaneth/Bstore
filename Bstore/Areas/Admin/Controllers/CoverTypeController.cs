using Bstore.DataAccess.Repository.IRepository;
using Bstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bstore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork _IUnitOfWork;

        public CoverTypeController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }
        public IActionResult Index()
        {

            IEnumerable<CoverType> CoverTypeObj = _IUnitOfWork.CoverType.GetAll();
            return View(CoverTypeObj);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {

            if (obj.Name == "")
            {
                ModelState.AddModelError("name", "Name cannot be null");
            }
            if (ModelState.IsValid)
            {
                _IUnitOfWork.CoverType.Add(obj);
                _IUnitOfWork.Save();
                TempData["success"] = "CoverType has been added";
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

            var objresult = _IUnitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (objresult == null)
            {
                return NotFound();
            }


            return View(objresult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {

            if (obj.Name == "")
            {
                ModelState.AddModelError("name", "Name can not be null");
            }
            if (ModelState.IsValid)
            {


                _IUnitOfWork.CoverType.Update(obj);
                _IUnitOfWork.Save();
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

            var objresult = _IUnitOfWork.CoverType.GetFirstOrDefault(x => x.Id == id);
            if (objresult == null)
            {
                return NotFound();
            }


            return View(objresult);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CoverType obj)
        {

            if (obj.Name == "")
            {
                ModelState.AddModelError("name", "Name can not be null");
            }
            if (ModelState.IsValid)
            {
                _IUnitOfWork.CoverType.Remove(obj);
                _IUnitOfWork.Save();
                TempData["success"] = "coverType has been Deleted";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
