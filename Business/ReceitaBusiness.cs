using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ReceitaBusiness : BaseBusiness<Receita>, IReceitaBusiness
    {
        public ReceitaBusiness(IRepository<Receita> context) : base(context)
        {

        }
    }
}
