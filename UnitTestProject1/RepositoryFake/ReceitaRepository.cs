using System;
using System.Linq;
using System.Collections.Generic;

using Entities;
using Business;

namespace UnitTestProject1.RepositoryFake
{
    public class ReceitaRepository : IRepository<Receita>
    {
        public List<Receita> Receitas { get; set; }

        public ReceitaRepository()
        {
            Receitas = new List<Receita>();
        }

        public void Create(Receita t)
        {
            t.Id = Receitas.Count > 0 ? Receitas.Max(d => d.Id) + 1 : 1;
            Receitas.Add(t);
        }

        public void Delete(Receita t)
        {
            var e = Receitas.Find(d => d.Id == t.Id);
            Receitas.Remove(e);
        }

        public Receita Find(int id)
        {
            return Receitas.Find(d => d.Id == id);
        }

        public IQueryable<Receita> FindAll()
        {
            return Receitas.AsQueryable<Receita>();
        }

        public void Update(Receita t)
        {
            var e = Receitas.Find(d => d.Id == t.Id);
            e.Categoria = t.Categoria;
            e.Data = t.Data;
            e.Observacao = t.Observacao;
            e.Valor = t.Valor;
        }
    }
}
