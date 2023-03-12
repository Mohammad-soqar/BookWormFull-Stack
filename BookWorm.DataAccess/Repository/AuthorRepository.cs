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
    public class AuthorRepository : Repository<Author> , IAuthorRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Author obj)
        {
            var objFromDb = _db.Authors.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.first_name = obj.first_name;
                objFromDb.last_name = obj.last_name;
               
                if (objFromDb.imageUrl != null)
                {
                    objFromDb.imageUrl = obj.imageUrl;
                }

            }
        }
    }
}
