using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidade;

namespace Infraestrutura.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Task<string> ValidarLogin(string usuario, string senha);
    }
}