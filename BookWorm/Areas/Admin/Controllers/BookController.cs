using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Data;


namespace BookWorm.Areas.Admin.Controllers
{
   
        [Area("Admin")]

    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _HostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _HostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? Id)
        {
            BookVM BookVM = new()
            {
                Book = new(),

                GenreList = (IEnumerable<System.Web.Mvc.SelectListItem>)_unitOfWork.Genre.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                AuthorList = (IEnumerable<System.Web.Mvc.SelectListItem>)_unitOfWork.Author.GetAll().Select(i => new SelectListItem
                {
                    Text = i.first_name,
                    Value = i.Id.ToString()
                })

            };
            if (Id == null || Id == 0)
            {
                return View(BookVM);
            }
            else
            {
                BookVM.Book = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == Id);
                return View(BookVM);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _HostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Images\Books");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Book.cover_image != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Book.cover_image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Book.cover_image = @"\Images\Books\" + fileName + extension;
                }
                if (obj.Book.Id == 0)
                {
                    _unitOfWork.Book.Add(obj.Book);
                }
                else
                {
                    _unitOfWork.Book.Update(obj.Book);
                }


                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }

            var GenreFromDb = _unitOfWork.Genre.GetFirstOrDefault(u => u.Id == Id);
            var AuthorFromDb = _unitOfWork.Author.GetFirstOrDefault(u => u.Id == Id);

            if (GenreFromDb == null || AuthorFromDb == null)
            {
                return NotFound();
            }
            return View();

        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var BookList = _unitOfWork.Book.GetAll(includeProperties: "Genre");
            return Json(new { data = BookList });
        }

        [HttpDelete]
        public IActionResult DeletePost(int? Id)
        {
            var obj = _unitOfWork.Book.GetFirstOrDefault(u => u.Id == Id);

            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_HostEnvironment.WebRootPath, obj.cover_image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Book.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Book deleted successfuly" });
            return RedirectToAction("Index");

            return View(Id);

        }


        #endregion

    }
}
