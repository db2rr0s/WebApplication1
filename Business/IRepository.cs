using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IRepository<T> where T: class
    {
        IQueryable<T> FindAll();
        T Find(int id);
        void Create(T t);
        void Update(T t);
        void Delete(T t);
    }
}
