using System;
using System.Linq;
using System.Collections.Generic;

using Entities;
using Business;

namespace UnitTestProject1.RepositoryFake
{
    public class DespesaRepository : IRepository<Despesa>
    {
        public List<Despesa> Despesas { get; set; }

        public DespesaRepository()
        {
            Despesas = new List<Despesa>();
        }

        public void Create(Despesa t)
        {
            t.Id = Despesas.Count > 0 ? Despesas.Max(d => d.Id) + 1 : 1;
            Despesas.Add(t);
        }

        public void Delete(Despesa t)
        {
            var e = Despesas.Find(d => d.Id == t.Id);
            Despesas.Remove(e);
        }

        public Despesa Find(int id)
        {
            return Despesas.Find(d => d.Id == id);
        }

        public IQueryable<Despesa> FindAll()
        {
            return Despesas.AsQueryable<Despesa>();
        }     

        public void Update(Despesa t)
        {
            var e = Despesas.Find(d => d.Id == t.Id);
            e.Categoria = t.Categoria;
            e.Data = t.Data;
            e.Observacao = t.Observacao;
            e.Valor = t.Valor;
        }
    }
}
