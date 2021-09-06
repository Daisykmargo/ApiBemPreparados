using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Aplicacao.Modelo.Cep;
using Aplicacao.Servico.Interface;

namespace Aplicacao.Servico
{
    public class CepServico : ICepServico
    {
        public async Task<CepModelo> BuscarCep(string cep)
        {
            try
            {

                string viaCEPUrl = $"https://viacep.com.br/ws/{cep}/json/";

                HttpClient ceps = new HttpClient();
                var response = await ceps.GetAsync(viaCEPUrl);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var dados = await response.Content.ReadAsAsync<CepModelo>();



                return dados;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}