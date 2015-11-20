using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Entities;
using WebApplication1.Models;
using Business;
using System.Globalization;

namespace WebApplication1.Api
{
    [Route("api/[controller]")]
    public class ReceitaController : Controller
    {
        private IReceitaBusiness _business;

        public ReceitaController(IReceitaBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        public IEnumerable<Receita> Get([FromQuery(Name = "StartDate")] string startDateString, [FromQuery(Name = "EndDate")] string endDateString, [FromQuery(Name = "Category")] string category)
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

            return _business.FindAll(r => (!startDate.HasValue || r.Data >= startDate.Value) && (!endDate.HasValue || r.Data <= endDate.Value) && (string.IsNullOrEmpty(category) || r.Categoria == category));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(_business.Find(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] ReceitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                _business.Create(new Receita()
                {
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
        public IActionResult Put(int id, [FromBody] ReceitaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var receita = new Receita()
                {
                    Id = id,
                    Valor = model.Valor,
                    Categoria = model.Categoria,
                    Data = model.Data,
                    Observacao = model.Observacao
                };

                _business.Update(receita);
                return new ObjectResult(model);
            }

            return new BadRequestObjectResult(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _business.Delete(new Receita()
            {
                Id = id
            });

            return new HttpStatusCodeResult(200);
        }
    }
}
