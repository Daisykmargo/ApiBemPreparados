using Aplicacao.Modelo.Usuario;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao.Servico.Interface
{
    public interface IUsuarioServico
    {
        Task<string> ValidarLogin(string usuario, string senha);
    }
}