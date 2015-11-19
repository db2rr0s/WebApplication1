using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IDespesaBusiness
    {
        List<Despesa> FindAll();
        List<Despesa> FindAll(Func<Despesa, bool> filter);
        Despesa Find(int id);
        void Create(Despesa d);
        void Update(Despesa d);
        void Delete(Despesa d);
    }
}
