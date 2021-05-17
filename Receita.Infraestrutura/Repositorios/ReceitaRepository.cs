using Receita.Dominio.Repositorios;
using Receita.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;

namespace Receita.Infraestrutura.Repositorios
{
    public class ReceitaRepository : IReceitaRepository
    {
        static HttpClient _httpClient;

        public ReceitaRepository()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
                _httpClient.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
            }
        }

        public Dominio.Entidades.Receita ObterReceitaPorNome(string nomeReceita)
        {
            var retorno = _httpClient.GetAsync($"search.php?s={nomeReceita}").Result;
            var resultado = retorno.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Dominio.Entidades.Receita>(resultado);
        }

        public TipoReceita ListarReceitasPorCategoria(string categoria)
        {
            var retorno = _httpClient.GetAsync($"filter.php?c={categoria}").Result;
            var resultado = retorno.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TipoReceita>(resultado);
        }

        public TipoReceita ListarReceitasPorPais(string pais)
        {
            var retorno = _httpClient.GetAsync($"filter.php?a={pais}").Result;
            var resultado = retorno.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<TipoReceita>(resultado);
        }

    }
}
