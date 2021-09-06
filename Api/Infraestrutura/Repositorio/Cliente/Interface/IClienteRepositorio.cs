using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio.Entidade;

namespace Infraestrutura.Repositorio
{
    public interface IClienteRepositorio
    {
        Task<ClienteDominio> ObterCliente(string cpf);
        Task<IEnumerable<ClienteDominio>> BuscarCliente();
        Task<ClienteDominio> GravarCliente(ClienteDominio cliente);
        Task<bool> AtualizarCliente(string cpf, ClienteDominio clienteAtualizacao);
        Task<bool> DeletarCliente(string cpf);
    }
}