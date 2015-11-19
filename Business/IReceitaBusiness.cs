using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IReceitaBusiness
    {
        List<Receita> FindAll();
        List<Receita> FindAll(Func<Receita, bool> filter);
        Receita Find(int id);
        void Create(Receita r);
        void Update(Receita r);
        void Delete(Receita r);
    }
}
