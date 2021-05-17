using Moq;
using Receita.Aplicacao;
using Receita.Dominio.Entidades;
using Receita.Dominio.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Receita.TesteUnitario.Aplicacao
{
    public class ReceitaAplicacaoTest
    {
        [Fact]
        public void ObterReceitaPorNome_Test()
        {
            var receitaReajusteRepository = new Mock<IReceitaRepository>();

            var application = new ReceitaAplicacao(receitaReajusteRepository.Object);

            var receita = new Receita.Dominio.Entidades.Receita()
            {
                meals = new List<DetalheReceita>() { new DetalheReceita { idMeal = "12345" } }
            };

            receitaReajusteRepository.Setup(a => a.ObterReceitaPorNome(It.IsAny<string>())).Returns(receita);

            var result = application.ObterReceitaPorNome("Penne");

            receitaReajusteRepository.Verify(r => r.ObterReceitaPorNome(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListarReceitasPorCategoria_Test()
        {
            var receitaReajusteRepository = new Mock<IReceitaRepository>();

            var application = new ReceitaAplicacao(receitaReajusteRepository.Object);

            var receita = new TipoReceita()
            {
                meals = new List<BaseReceita>() { new BaseReceita { idMeal = "12345" } }
            };

            receitaReajusteRepository.Setup(a => a.ListarReceitasPorCategoria(It.IsAny<string>())).Returns(receita);

            var result = application.ListarReceitasPorCategoria("Vegetarian");

            receitaReajusteRepository.Verify(r => r.ListarReceitasPorCategoria(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void ListarReceitasPorPais_Test()
        {
            var receitaReajusteRepository = new Mock<IReceitaRepository>();

            var application = new ReceitaAplicacao(receitaReajusteRepository.Object);

            var receita = new TipoReceita()
            {
                meals = new List<BaseReceita>() { new BaseReceita { idMeal = "12345" } }
            };

            receitaReajusteRepository.Setup(a => a.ListarReceitasPorPais(It.IsAny<string>())).Returns(receita);

            var result = application.ListarReceitasPorPais("Italian");

            receitaReajusteRepository.Verify(r => r.ListarReceitasPorPais(It.IsAny<string>()), Times.Once);
        }

    }
}
