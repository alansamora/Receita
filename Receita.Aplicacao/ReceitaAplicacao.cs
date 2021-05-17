using Receita.Aplicacao.Interfaces;
using Receita.Dominio.Repositorios;
using Receita.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Receita.Aplicacao
{
    public class ReceitaAplicacao : IReceitaAplicacao
    {
        private readonly IReceitaRepository _receitaRepository;

        public ReceitaAplicacao(IReceitaRepository receitaRepository)
        {
            _receitaRepository = receitaRepository;
        }

        public Receita.Dominio.Entidades.Receita ObterReceitaPorNome(string nomeReceita)
        {
            return _receitaRepository.ObterReceitaPorNome(nomeReceita);
        }

        public TipoReceita ListarReceitasPorCategoria(string categoria)
        {
            return _receitaRepository.ListarReceitasPorCategoria(categoria);
        }

        public TipoReceita ListarReceitasPorPais(string pais)
        {
            return _receitaRepository.ListarReceitasPorPais(pais);
        }
    }
}
