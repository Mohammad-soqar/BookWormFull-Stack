using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWorm.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository Book { get; }
        IGenreRepository Genre { get; }
        IAuthorRepository Author { get; }


        void Save();
    }
}
