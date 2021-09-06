using System;
using System.ComponentModel;

namespace Dominio.Entidade
{
    public class ClienteDominio
    {
        public int Id {get; private set; }
        public string Cpf {get; private set; }
        public string Nome {get; private set; }
        public DateTime DtNascimento {get; private set; }
        public string Genero {get; private set; }
        public decimal VlrSalario {get; private set; }
        public string Logradouro {get; private set; }
        public string NumeroResidencia {get; private set; }
        public string Bairro {get; private set; }
        public string Cidade {get; private set; }
        public string Cep {get; private set; }
        public string UsuarioAtualizacao {get; private set; }
        public DateTime DataAtualizacao {get; private set; }

        protected  ClienteDominio(){} 

                //Metodo construtor
        public ClienteDominio(

            string cpf, 
            string nome, 
            DateTime dtNascimento, 
            string genero, 
            decimal vlrSalario, 
            string logradouro, 
            string numeroResidencia, 
            string bairro, 
            string cidade, 
            string cep, 
            string usuarioAtualizacao 
            

            )
        {
                Cpf = cpf;
                Nome = nome;
                DtNascimento = dtNascimento;
                Genero = genero;
                VlrSalario = vlrSalario;
                Logradouro = logradouro;
                NumeroResidencia = numeroResidencia;
                Bairro = bairro;
                Cidade = cidade;
                Cep = cep;
                UsuarioAtualizacao = usuarioAtualizacao;
                DataAtualizacao = DateTime.Now;
        }
                        
        public void AtualizarCliente(
             
            string nome, 
            DateTime dtNascimento, 
            string genero, 
            decimal vlrSalario, 
            string logradouro, 
            string numeroResidencia, 
            string bairro, 
            string cidade, 
            string cep, 
            string usuarioAtualizacao
                        
            )
        {
                Nome = nome;
                DtNascimento = dtNascimento;
                Genero = genero;
                VlrSalario = vlrSalario;
                Logradouro = logradouro;
                NumeroResidencia = numeroResidencia;
                Bairro = bairro;
                Cidade = cidade;
                Cep = cep;
                UsuarioAtualizacao = usuarioAtualizacao;
                DataAtualizacao = DateTime.Now;

            
        }

    }

}