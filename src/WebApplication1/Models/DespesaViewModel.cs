using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DespesaViewModel
    {        
        [Required(ErrorMessage = "Valor Obrigatório!")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Categoria Obrigatória!")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Data Obrigatório!")]        
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Observação Obrigatório!")]
        public string Observacao { get; set; }
    }
}
