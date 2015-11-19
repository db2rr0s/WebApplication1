using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Business;
using WebApplication1.Models;
using Entities;

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
        public IEnumerable<Despesa> Get([FromQuery(Name = "StartDate")] DateTime? startDate, [FromQuery(Name = "EndDate")] DateTime? endDate, [FromQuery(Name = "Category")] string category)
        {
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
