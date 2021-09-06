using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacao.Modelo.Cliente;
using Aplicacao.Modelo.Proposta;


namespace Aplicacao.Servico.Interface
{
    public interface IPropostaServico
    {
        Task<IEnumerable<PropostaModelo>> BuscarProposta();
        Task<PropostaModelo> CriarProposta(PropostaEnvioModelo proposta);
        Task<PropostaModelo> AtualizarProposta(int idProposta, PropostaEnvioModelo proposta);
        Task<decimal> CalcularFinanciamento(decimal vlrSolicitado, int prazo);
    }
}