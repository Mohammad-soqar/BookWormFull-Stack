using BookWorm.DataAccess.Data;
using BookWorm.DataAccess.Repository.IRepository;
using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        private readonly ApplicationDbContext _db;

        public GenreRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Genre obj)
        {
            var objFromDb = _db.Genres.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                

            }
        }

    }
}
