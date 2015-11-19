using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Despesa
    {
        public int Id { get; set; }
        public Decimal Valor { get; set; }
        public String Categoria { get; set; }
        public DateTime Data { get; set; }
        public String Observacao { get; set; }
    }
}
