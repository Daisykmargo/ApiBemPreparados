using Aplicacao.Modelo.Conveniada;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao.Servico.Interface
{
    public interface IConveniadaServico
    {
        Task<IEnumerable<ConveniadaModelo>> BuscarConveniada();
        
    }
}