using Aplicacao.Modelo.Cep;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao.Servico.Interface
{
    public interface ICepServico
    {
        Task<CepModelo>BuscarCep(string cep);
    }
}