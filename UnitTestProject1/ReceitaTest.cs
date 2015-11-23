using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using UnitTestProject1.RepositoryFake;
using Business;
using Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class ReceitaTest
    {
        [TestMethod]
        public void FindAllTest()
        {
            ReceitaRepository repository = new ReceitaRepository();
            ReceitaBusiness business = new ReceitaBusiness(repository);

            repository.Receitas.Add(new Receita() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 });
            repository.Receitas.Add(new Receita() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test2", Valor = 250 });
            repository.Receitas.Add(new Receita() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test3", Valor = 180 });
            repository.Receitas.Add(new Receita() { Categoria = "FindAllTest", Data = DateTime.Now, Observacao = "Test4", Valor = 100 });

            Assert.AreEqual(4, business.FindAll().Count, "Total de itens diferente de 4");
        }

        [TestMethod]
        public void FindTest()
        {
            ReceitaRepository repository = new ReceitaRepository();
            ReceitaBusiness business = new ReceitaBusiness(repository);

            var expected = new Receita() { Id = 1, Categoria = "FindTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 };
            repository.Receitas.Add(expected);

            var actual = business.Find(expected.Id);

            Assert.IsNotNull(actual, "Objeto procurado retornou nulo");
            Assert.AreSame(expected, actual, "Objeto procurado retornou diferente do adicionado");
        }

        [TestMethod]
        public void CreateTest()
        {
            ReceitaRepository repository = new ReceitaRepository();
            ReceitaBusiness business = new ReceitaBusiness(repository);

            var expected = new Receita() { Categoria = "CreateTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 };

            business.Create(expected);

            var actual = business.Find(expected.Id);

            Assert.AreNotEqual(0, expected.Id, "Objeto criado tem id = 0");
            Assert.IsNotNull(actual, "Objeto procurado é nulo");
            Assert.AreSame(expected, actual, "Objeto procurado é diferente do criado");
        }

        [TestMethod]
        public void DeleteTest()
        {
            ReceitaRepository repository = new ReceitaRepository();
            ReceitaBusiness business = new ReceitaBusiness(repository);

            var expected = new Receita() { Id = 1, Categoria = "DeleteTest", Data = DateTime.Now, Observacao = "Test1", Valor = 190 };
            repository.Receitas.Add(expected);

            business.Delete(new Receita() { Id = 1 });
            var actual = business.Find(expected.Id);

            Assert.IsNull(actual, "Objeto procurado não é nulo");
        }
    }
}
