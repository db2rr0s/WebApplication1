using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Business;
using WebApplication1.Models;
using System.Globalization;

namespace WebApplication1.Api
{
    [Route("api/[controller]")]
    public class RelatorioController : Controller
    {
        private IReceitaBusiness _receitaBus;
        private IDespesaBusiness _despesaBus;

        public RelatorioController(IReceitaBusiness receitaBus, IDespesaBusiness despesaBus)
        {
            _receitaBus = receitaBus;
            _despesaBus = despesaBus;
        }
        
        public IEnumerable<RelatorioItemViewModel> Get([FromQuery(Name = "StartDate")] string startDateString, [FromQuery(Name = "EndDate")] string endDateString, [FromQuery(Name = "ApplyGroup")] bool? applyGroup)
        {
            DateTime? startDate = null, endDate = null;

            // Como o AspNet.Localization não está estável, optei por receber string e fazer a conversão na mão utilizando a cultura local
            if(!string.IsNullOrEmpty(startDateString))
            {
                startDate = Convert.ToDateTime(startDateString, new CultureInfo("pt-BR"));
            }

            if(!string.IsNullOrEmpty(endDateString))
            {
                endDate = Convert.ToDateTime(endDateString, new CultureInfo("pt-BR"));
            }

            var receitas = from r in _receitaBus.FindAll(r => (!startDate.HasValue || r.Data >= startDate.Value) && (!endDate.HasValue || r.Data <= endDate.Value))
                           select new RelatorioItemViewModel()
                           {
                               Tipo = "Receita",
                               Categoria = r.Categoria,
                               Data = r.Data,
                               Observacao = r.Observacao,
                               Valor = r.Valor
                           };

            var despesas = from d in _despesaBus.FindAll(d => (!startDate.HasValue || d.Data >= startDate.Value) && (!endDate.HasValue || d.Data <= endDate.Value))
                           select new RelatorioItemViewModel()
                           {
                               Tipo = "Despesa",
                               Categoria = d.Categoria,
                               Data = d.Data,
                               Observacao = d.Observacao,
                               Valor = d.Valor
                           };

            if(applyGroup.HasValue && applyGroup.Value)
            {
                var items = receitas.Union(despesas).OrderBy(o => o.Categoria);
                List<RelatorioItemViewModel> list = new List<RelatorioItemViewModel>();
                RelatorioItemViewModel currentItem = null;

                foreach(var item in items)
                {
                    if(currentItem == null)
                    {
                        currentItem = new RelatorioItemViewModel() { Categoria = item.Categoria };
                        currentItem.SubItens = new List<RelatorioItemViewModel>();
                    } else if(currentItem.Categoria != item.Categoria)
                    {
                        list.Add(currentItem);
                        currentItem = new RelatorioItemViewModel() { Categoria = item.Categoria };
                        currentItem.SubItens = new List<RelatorioItemViewModel>();
                    }

                    currentItem.SubItens.Add(item);
                }

                if(currentItem != null)
                {
                    list.Add(currentItem);
                }

                return list;
            }

            return receitas.Union(despesas).OrderBy(o => o.Data);
        }
    }
}
