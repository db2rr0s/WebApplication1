using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DespesaBusiness : BaseBusiness<Despesa>, IDespesaBusiness
    {
        public DespesaBusiness(IRepository<Despesa> context) : base(context)
        {

        }
    }
}
