using Microsoft.EntityFrameworkCore;
using NetSevenCommerece.DataAccess.Data;
using NetSevenCommerece.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NetSevenCommerece.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDBContext _dbContext;
        internal DbSet<T> _dbSet;
        protected Repository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            this._dbSet=dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = _dbSet;
            query= query.Where(filter);
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _dbSet;
            
            return query.ToList();
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public  Task<int> Save()
        {
            try
            {
                return  _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

    }
}
