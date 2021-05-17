using Microsoft.AspNetCore.Mvc;
using Moq;
using Receita.Api.Controllers;
using Receita.Aplicacao.Interfaces;
using Receita.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Receita.TesteUnitario.Controller
{
    public class ReceitaControllerTest
    {
        [Fact]
        public void Get_ObterReceitaPorNome_Sucesso_Test()
        {
            var application = new Mock<IReceitaAplicacao>();

            var controller = new ReceitaController(application.Object);

            var receita = new Receita.Dominio.Entidades.Receita()
            {
                meals = new List<DetalheReceita>() { new DetalheReceita { idMeal = "12345" } }
            };

            application.Setup(a => a.ObterReceitaPorNome(It.IsAny<string>())).Returns(receita);
            var result = controller.GetReceita("Penne");

            Assert.IsType<OkObjectResult>(result);
            application.Verify(a => a.ObterReceitaPorNome(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Get_ListarReceitasPorCategoria_Sucesso_Test()
        {
            var application = new Mock<IReceitaAplicacao>();

            var controller = new ReceitaController(application.Object);

            var receita = new TipoReceita
            {
                meals = new List<BaseReceita>() { new BaseReceita { idMeal = "12345" } }
            };

            application.Setup(a => a.ListarReceitasPorCategoria(It.IsAny<string>())).Returns(receita);
            var result = controller.GetCategoria("Vegetarian");

            Assert.IsType<OkObjectResult>(result);
            application.Verify(a => a.ListarReceitasPorCategoria(It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void Get_ListarReceitasPorPais_Sucesso_Test()
        {
            var application = new Mock<IReceitaAplicacao>();

            var controller = new ReceitaController(application.Object);

            var receita = new TipoReceita
            {
                meals = new List<BaseReceita>() { new BaseReceita { idMeal = "12345" } }
            };

            application.Setup(a => a.ListarReceitasPorPais(It.IsAny<string>())).Returns(receita);
            var result = controller.GetPais("Vegetarian");

            Assert.IsType<OkObjectResult>(result);
            application.Verify(a => a.ListarReceitasPorPais(It.IsAny<string>()), Times.Once);
        }

    }
}
