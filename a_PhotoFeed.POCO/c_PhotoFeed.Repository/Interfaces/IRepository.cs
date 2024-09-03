using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace c_PhotoFeed.Repository.Interfaces
{
    public interface IRepository<T>
    {
        void Add(T newElem);
        void Remove(T removedElem);
        List<T> GetAll();
        List<T> Find(Expression<Func<T, bool>> predicate);
        bool Exists(Expression<Func<T, bool>> predicate);
        List<T> OrderBy(Expression<Func<T, int>> predicate);
        List<T> OrderByDescending(Expression<Func<T, int>> predicate);
        List<T> Where(Expression<Func<T, bool>> predicate);
        void Save();
    }
}
