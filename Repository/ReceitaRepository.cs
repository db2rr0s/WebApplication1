using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ReceitaRepository : BaseRepository<Receita>
    {
        public ReceitaRepository(WebApplication1DbContext context) : base(context)
        {

        }
    }
}
