using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Business;
using WebApplication1.Models;
using Entities;
using System.Globalization;

namespace WebApplication1.Api
{
    [Route("api/[controller]")]
    public class DespesaController : Controller
    {
        private IDespesaBusiness _business;
        
        public DespesaController(IDespesaBusiness business)
        {
            _business = business;
        }   
           
        [HttpGet]
        public IEnumerable<Despesa> Get([FromQuery(Name = "StartDate")] string startDateString, [FromQuery(Name = "EndDate")] string endDateString, [FromQuery(Name = "Category")] string category)
        {
            DateTime? startDate = null, endDate = null;

            // Como o AspNet.Localization não está estável, optei por receber string e fazer a conversão na mão utilizando a cultura local
            if (!string.IsNullOrEmpty(startDateString))
            {
                startDate = Convert.ToDateTime(startDateString, new CultureInfo("pt-BR"));
            }

            if (!string.IsNullOrEmpty(endDateString))
            {
                endDate = Convert.ToDateTime(endDateString, new CultureInfo("pt-BR"));
            }

            return _business.FindAll(d => (!startDate.HasValue || d.Data >= startDate.Value) && (!endDate.HasValue || d.Data <= endDate.Value) && (string.IsNullOrEmpty(category) || d.Categoria == category));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(_business.Find(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] DespesaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _business.Create(new Despesa() {
                    Valor = model.Valor,
                    Categoria = model.Categoria,
                    Data = model.Data,
                    Observacao = model.Observacao
                });

                return new ObjectResult(model);                
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] DespesaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var despesa = new Despesa()
                {
                    Id = id,
                    Valor = model.Valor,
                    Categoria = model.Categoria,
                    Data = model.Data,
                    Observacao = model.Observacao
                };

                _business.Update(despesa);
                return new ObjectResult(model);
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _business.Delete(new Despesa()
            {
                Id = id
            });

            return new HttpStatusCodeResult(200);
        }
    }
}
