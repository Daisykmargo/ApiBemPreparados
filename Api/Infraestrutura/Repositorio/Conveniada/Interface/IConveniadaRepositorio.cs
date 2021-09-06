using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidade;

namespace Infraestrutura.Repositorio
{
    public interface IConveniadaRepositorio
    {
        Task<IEnumerable<ConveniadaDominio>> BuscarConveniada();

    }
}