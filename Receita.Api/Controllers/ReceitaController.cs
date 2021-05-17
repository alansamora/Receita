using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Receita.Aplicacao.Interfaces;
using Receita.Dominio.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Receita.Api.Controllers
{
    /// <summary>
    /// Serviço de Receita
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly IReceitaAplicacao _receitaAplicacao;

        public ReceitaController(IReceitaAplicacao receitaAplicacao)
        {
            _receitaAplicacao = receitaAplicacao;
        }

        /// <summary>
        /// Buscar uma receita pelo nome.
        /// </summary>
        /// <param name="nomeReceita">Nome da receita</param>
        /// <returns>Objeto receita</returns>
        // GET Buscar a receita pelo nome
        [HttpGet("{nomeReceita}")]
        public IActionResult GetReceita(string nomeReceita)
        {
            if (!string.IsNullOrWhiteSpace(nomeReceita))
            {
                var receita = _receitaAplicacao.ObterReceitaPorNome(nomeReceita);
                if (receita != null) return new OkObjectResult(receita);
                return new NoContentResult();
            }
            return BadRequest();
        }

        /// <summary>
        /// Buscar receitas pela categoria.
        /// </summary>
        /// <param name="categoria">Nome da categoria</param>
        /// <returns>Objeto tiporeceita</returns>
        // GET Buscar receitas pela categoria
        [HttpGet("{categoria}/categoria")]
        public IActionResult GetCategoria(string categoria)
        {
            if (!string.IsNullOrWhiteSpace(categoria))
            {
                var receita = _receitaAplicacao.ListarReceitasPorCategoria(categoria);
                if (receita != null) return new OkObjectResult(receita);
                return new NoContentResult();
            }
            return BadRequest();
        }

        /// <summary>
        /// Buscar receitas pelo país.
        /// </summary>
        /// <param name="pais">Nome do país</param>
        /// <returns>Objeto tiporeceita</returns>
        // GET Buscar receitas pelo país
        [HttpGet("{pais}/pais")]
        public IActionResult GetPais(string pais)
        {
            if (!string.IsNullOrWhiteSpace(pais))
            {
                var receita = _receitaAplicacao.ListarReceitasPorPais(pais);
                if (receita != null) return new OkObjectResult(receita);
                return new NoContentResult();
            }
            return BadRequest();
        }

    }
}
