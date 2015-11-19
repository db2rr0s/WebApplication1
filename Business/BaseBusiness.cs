using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public abstract class BaseBusiness<T> where T: class
    {
        protected IRepository<T> _context;

        public BaseBusiness(IRepository<T> context)
        {
            _context = context; 
        }

        public List<T> FindAll()
        {
            return _context.FindAll().ToList();
        }

        public List<T> FindAll(Func<T, bool> filter)
        {            
            return _context.FindAll().Where(filter).ToList();
        }

        public T Find(int id)
        {
            return _context.Find(id);
        }

        public void Create(T t)
        {
            _context.Create(t);
        }

        public void Update(T t)
        {
            _context.Update(t);
        }

        public void Delete(T t)
        {
            _context.Delete(t);
        }
    }
}
