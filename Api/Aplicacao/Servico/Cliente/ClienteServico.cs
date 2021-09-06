using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Modelo.Cliente;
using Aplicacao.Servico.Interface;
using Dominio.Entidade;
using Infraestrutura.Repositorio;

namespace Aplicacao.Servico
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _clienteRepositorio;
        public ClienteServico(IClienteRepositorio clienteRepositorio)
        {
            _clienteRepositorio = clienteRepositorio;
        }

        
        public async Task<IEnumerable<ClienteModelo>> BuscarCliente()
        {
            var cliente = await _clienteRepositorio.BuscarCliente();

            return cliente.Select(cliente => new ClienteModelo(cliente));
        }
        public async Task<ClienteModelo> CriarCliente(ClienteEnvioModelo cliente)
        {
            ValidarIdade(cliente.DtNascimento);

            var clientes = new ClienteDominio(
                
                cliente.Cpf, 
                cliente.Nome, 
                cliente.DtNascimento, 
                cliente.Genero, 
                cliente.VlrSalario, 
                cliente.Logradouro, 
                cliente.NumeroResidencia, 
                cliente.Bairro, 
                cliente.Cidade, 
                cliente.Cep, 
                cliente.UsuarioAtualizacao 
            );

            var novoCliente = await _clienteRepositorio.GravarCliente(clientes);
            //_mensagens.SetHttpStatus(HttpStatusCode.Created);

            return new ClienteModelo(novoCliente);
        }

        public async Task<ClienteModelo> AtualizarCliente(string cpfCliente, ClienteEnvioModelo clienteAtualizacao)
        {
            var cliente = await _clienteRepositorio.ObterCliente(cpfCliente);

            if (cliente == null)
            {
               throw new ArgumentException($"Nenhum registro localizado com cpf {cpfCliente}.");
                
            }

            cliente.AtualizarCliente(
                
                
                clienteAtualizacao.Nome, 
                clienteAtualizacao.DtNascimento, 
                clienteAtualizacao.Genero, 
                clienteAtualizacao.VlrSalario, 
                clienteAtualizacao.Logradouro, 
                clienteAtualizacao.NumeroResidencia, 
                clienteAtualizacao.Bairro, 
                clienteAtualizacao.Cidade, 
                clienteAtualizacao.Cep, 
                clienteAtualizacao.UsuarioAtualizacao 
                
                );

            await _clienteRepositorio.AtualizarCliente(cpfCliente, cliente);

            return new ClienteModelo(cliente);
        }

        public async Task<bool> RemoverCliente(string cpfCliente)
        {
            var cliente = await _clienteRepositorio.ObterCliente(cpfCliente);

            if (cliente == null)
            {
                throw new ArgumentException($"Nenhum registro localizado com id {cpfCliente}.");
                
            }

            return await _clienteRepositorio.DeletarCliente(cpfCliente);
        }

        private void ValidarIdade(DateTime dtNascimento)
        {
            var idade = (DateTime.Now.DayOfYear - dtNascimento.DayOfYear);

            if (idade < 18)
            {
                throw new ArgumentException("Cliente não pode ter menos de 18 anos");
            }
        }

    }
}