using Receita.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Receita.Aplicacao.Interfaces
{
    public interface IReceitaAplicacao
    {
        Receita.Dominio.Entidades.Receita ObterReceitaPorNome(string nomeReceita);
        TipoReceita ListarReceitasPorCategoria(string categoria);
        TipoReceita ListarReceitasPorPais(string pais);
    }
}
