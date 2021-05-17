using Moq;
using Receita.Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Receita.TesteUnitario.Repositorio
{
    public class ReceitaRepositoryTest
    {
        [Fact]
        public void ObterReceitaPorNome_Test()
        {
            var repositorio = new ReceitaRepository();

            var retorno = repositorio.ObterReceitaPorNome("Penne");

            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.meals);
        }

        [Fact]
        public void ListarReceitasPorCategoria_Test()
        {
            var repositorio = new ReceitaRepository();

            var retorno = repositorio.ListarReceitasPorCategoria("Vegetarian");

            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.meals);
        }

        [Fact]
        public void ListarReceitasPorPais_Test()
        {
            var repositorio = new ReceitaRepository();

            var retorno = repositorio.ListarReceitasPorPais("Italian");

            Assert.NotNull(retorno);
            Assert.NotEmpty(retorno.meals);
        }

    }
}
