using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class BaseRepository<T> : IDisposable, IRepository<T> where T : class
    {
        public WebApplication1DbContext _context;

        public BaseRepository(WebApplication1DbContext context)
        {
            _context = context;
        }

        public void Create(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
        }

        public void Delete(T t)
        {
            var dbSet = _context.Set<T>();
            var e = _context.Entry<T>(t);
            if (e.State == System.Data.Entity.EntityState.Detached)
                dbSet.Attach(t);
            dbSet.Remove(t);
            _context.SaveChanges();
        }

        public T Find(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public void Update(T t)
        {
            _context.Entry(t).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {
                _context.Dispose();
            }
        }
    }
}
