using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidade;

namespace Infraestrutura.Repositorio
{
    public interface IPropostaRepositorio
    {
        Task<PropostaDominio> ObterProposta(int id);
        Task<IEnumerable<PropostaDominio>> BuscarProposta();
        Task<PropostaDominio> GravarProposta(PropostaDominio proposta);
        Task<bool> AtualizarProposta(int id, PropostaDominio propostaAtualizacao);
         Task<decimal> ObterProximoNumeroProposta();
    }
}