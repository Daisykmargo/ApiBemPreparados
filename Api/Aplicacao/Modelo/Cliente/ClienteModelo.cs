using System;
using Dominio.Entidade;

namespace Aplicacao.Modelo.Cliente
{
    public class ClienteModelo
    {
        public int Id { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }

        public DateTime DtNascimento { get; set; }

        public string Genero { get; set; }

        public decimal VlrSalario { get; set; }

        public string Logradouro { get; set; }

        public string NumeroResidencia { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }

        public string UsuarioAtualizacao { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public ClienteModelo(ClienteDominio dominio)
        {
            Id = dominio.Id;
            Cpf = dominio.Cpf;
            Nome = dominio.Nome;
            DtNascimento = dominio.DtNascimento;
            Genero = dominio.Genero;
            VlrSalario = dominio.VlrSalario;
            Logradouro = dominio.Logradouro;
            NumeroResidencia = dominio.NumeroResidencia;
            Bairro = dominio.Bairro;
            Cidade = dominio.Cidade;
            Cep = dominio.Cep;
            UsuarioAtualizacao = dominio.UsuarioAtualizacao;
            DataAtualizacao = dominio.DataAtualizacao;
        }
    }
}