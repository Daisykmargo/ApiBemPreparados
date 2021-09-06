using Aplicacao.Modelo.Cliente;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    [Authorize]
    public class ClienteController : ControllerBase
    {

        private readonly IClienteServico _clienteServico;

        public ClienteController(IClienteServico clienteServico)
        {
            _clienteServico = clienteServico;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteModelo>> Get()
        {
            var clientes = await _clienteServico.BuscarCliente();
            return clientes;
        }

        [HttpPost]
        public async Task<ClienteModelo> Post([FromBody] ClienteEnvioModelo cliente)
        {
            var novoCliente = await _clienteServico.CriarCliente(cliente);
            return novoCliente;
        }

        [HttpPut("{cpfCliente}")]
        public async Task<ClienteModelo> Put([FromRoute] string cpfCliente, [FromBody] ClienteEnvioModelo cliente)
        {
            var clienteAtualizado = await _clienteServico.AtualizarCliente(cpfCliente, cliente);
            return clienteAtualizado;
        }

        [HttpDelete("{cpfCliente}")]
        
        public async Task<bool> Delete(string cpfCliente)
        {
            var clienteRemovido = await _clienteServico.RemoverCliente(cpfCliente);
            return clienteRemovido;
        }
    }
}