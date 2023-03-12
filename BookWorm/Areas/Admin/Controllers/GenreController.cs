using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Areas.Admin.Controllers
{
        [Area("Admin")]

    public class GenreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
       

        public GenreController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }
        public IActionResult Index()
        {
            IEnumerable<Genre> objCategoryList = _unitOfWork.Genre.GetAll();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Genre.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Genre");
            }
            return View(obj);

        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var GenreFromDbFirst = _unitOfWork.Genre.GetFirstOrDefault(u => u.Id == Id);

            if (GenreFromDbFirst == null)
            {
                return NotFound();
            }
            return View(GenreFromDbFirst);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Genre.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
