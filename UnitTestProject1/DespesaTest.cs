using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestProject1.RepositoryFake;
using Business;
using Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class DespesaTest
    {
        [TestMethod]
        public void FindAllTest()
        {
            DespesaRepository repository = new DespesaRepository();
            DespesaBusiness business = new DespesaBusiness(repository);

            repository.Despesas.Add(new Despesa() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 });
            repository.Despesas.Add(new Despesa() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test2", Valor = 250 });
            repository.Despesas.Add(new Despesa() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test3", Valor = 180 });
            repository.Despesas.Add(new Despesa() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test4", Valor = 100 });

            Assert.AreEqual(4, business.FindAll().Count, "Total de itens diferente de 4");
        }

        [TestMethod]
        public void FindTest()
        {
            DespesaRepository repository = new DespesaRepository();
            DespesaBusiness business = new DespesaBusiness(repository);

            var expected = new Despesa() { Id = 1, Categoria = "FindTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 };
            repository.Despesas.Add(expected);

            var actual = business.Find(expected.Id);

            Assert.IsNotNull(actual, "Objeto procurado retornou nulo");
            Assert.AreSame(expected, actual, "Objeto procurado retornou diferente do adicionado");
        }

        [TestMethod]
        public void CreateTest()
        {
            DespesaRepository repository = new DespesaRepository();
            DespesaBusiness business = new DespesaBusiness(repository);

            var expected = new Despesa() { Categoria = "CreateTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 };

            business.Create(expected);

            var actual = business.Find(expected.Id);

            Assert.AreNotEqual(0, expected.Id, "Objeto criado tem id = 0");
            Assert.IsNotNull(actual, "Objeto procurado é nulo");
            Assert.AreSame(expected, actual, "Objeto procurado é diferente do criado");
        }

        [TestMethod]
        public void DeleteTest()
        {
            DespesaRepository repository = new DespesaRepository();
            DespesaBusiness business = new DespesaBusiness(repository);

            var expected = new Despesa() { Id = 1, Categoria = "DeleteTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 };
            repository.Despesas.Add(expected);

            business.Delete(new Despesa() { Id = 1 });
            var actual = business.Find(expected.Id);

            Assert.IsNull(actual, "Objeto procurado não é nulo");
        }
    }
}
