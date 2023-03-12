using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Book = new BookRepository(_db);
            Author = new AuthorRepository(_db);
            Genre = new GenreRepository(_db);

        }
        public IBookRepository Book { get; private set; }
        public IAuthorRepository Author { get; private set; }
        public IGenreRepository Genre { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
