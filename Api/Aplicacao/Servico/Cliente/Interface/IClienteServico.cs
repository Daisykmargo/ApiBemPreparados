using Aplicacao.Modelo.Cliente;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Aplicacao.Servico.Interface
{
    public interface IClienteServico
    {
        Task<IEnumerable<ClienteModelo>> BuscarCliente();
        Task<ClienteModelo> CriarCliente(ClienteEnvioModelo cliente);
        Task<ClienteModelo> AtualizarCliente(string cpfCliente, ClienteEnvioModelo cliente);
        Task<bool> RemoverCliente(string cpfCliente);
    }
}