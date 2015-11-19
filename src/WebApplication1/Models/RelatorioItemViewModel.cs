using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class RelatorioItemViewModel
    {
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Categoria { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public List<RelatorioItemViewModel> SubItens { get; set; }
    }    
}
