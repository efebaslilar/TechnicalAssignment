using DataAccessLayer.Abstracts;
using DataAccessLayer.ContextInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Implamentations
{
    public class Repository<T, Id> : IRepository<T, Id> where T : class, new()
    {
        //dependency injection
        private protected readonly MyContext _myContext;

        public Repository(MyContext myContext)
        {
            _myContext = myContext;
        }

        public bool Add(T entity)
        {
            try
            {
                _myContext.Set<T>().Add(entity);
                return _myContext.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _myContext.Set<T>().Remove(entity);
                return _myContext.SaveChanges() > 0 ? true : false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, string includeEntities = null)
        {
            try
            {
                IQueryable<T> query = _myContext.Set<T>(); // select * from Books
                if (filter != null)
                {
                    query = query.Where(filter); // select * from Books where PageNumber<300 and AuthorId=120 ...
                }
                if (includeEntities != null) //innerjoin
                {
                    foreach (var item in includeEntities.Split(","))
                    {
                        query = query.Include(item);
                    }
                }
                return query;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T GetByConditions(Expression<Func<T, bool>> filter, string includeEntities = null)
        {
            try
            {
                IQueryable<T> query = _myContext.Set<T>(); // select * from Product
                if (filter != null)
                {
                    query = query.Where(filter); // select * from Product where xx ...
                }
                if (includeEntities != null) //innerjoin
                {
                    foreach (var item in includeEntities.Split(","))
                    {
                        query = query.Include(item);
                    }
                }
                return query.FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public T GetById(Id id)
        {
            try
            {
                return _myContext.Set<T>().Find(id);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Update(T entity)
        {
            try
            {
                _myContext.Set<T>().Update(entity);
                return _myContext.SaveChanges() > 0 ? true : false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
