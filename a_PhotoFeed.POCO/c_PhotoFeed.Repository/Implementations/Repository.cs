using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using a_PhotoFeed.POCO;
using b_PhotoFeed.DataAccess;
using c_PhotoFeed.Repository.Interfaces;

namespace c_PhotoFeed.Repository.Implementations
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IDbSet<T> _dbSet;
        private readonly DbContext _context;

        public Repository(IPhotoFeedContext context)
        {
            _dbSet = context.Set<T>();
            _context = context.Context;
        }

        public void Add(T newElem)
        {
            _dbSet.Add(newElem);
        }

        public void Remove(T removedElem)
        {
            _dbSet.Remove(removedElem);
        }

        public bool Exists(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).ToList().Count > 0;

        public List<T> Find(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).ToList();

        public List<T> GetAll() => _dbSet.ToList();

        public List<T> OrderBy(Expression<Func<T, int>> predicate) => _dbSet.OrderBy(predicate).ToList();

        public List<T> OrderByDescending(Expression<Func<T, int>> predicate) => _dbSet.OrderByDescending(predicate).ToList();

        public List<T> Where(Expression<Func<T, bool>> predicate) => _dbSet.Where(predicate).ToList();

        public void Save()
        {
             _context.SaveChanges();
        }

    }
}
