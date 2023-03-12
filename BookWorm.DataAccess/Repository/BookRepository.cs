using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
       

        public void Update(Book obj)
        {
            var objFromDb = _db.Books.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.title = obj.title;
                objFromDb.description = obj.description;
                objFromDb.AuthorId = obj.AuthorId;
                objFromDb.GenreId = obj.GenreId;
                objFromDb.publisher = obj.publisher;

                objFromDb.isbn = obj.isbn;
                objFromDb.publication_date = obj.publication_date;
                if (objFromDb.cover_image != null)
                {
                    objFromDb.cover_image = obj.cover_image;
                }

            }
        }
    }
}
