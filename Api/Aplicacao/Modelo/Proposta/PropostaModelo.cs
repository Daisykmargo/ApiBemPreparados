using System;
using Dominio.Entidade;

namespace Aplicacao.Modelo.Proposta
{
    public class PropostaModelo
    {
         public int Id {get; set; }

        public decimal Proposta {get; set; }

        public string Cpf {get; set; }

        public string Conveniada {get; set; }

        public decimal VlrSolicitado {get; set; }

        public decimal Prazo {get; set; }

        public decimal VlrFinanciado {get; set; }

        public string Situacao {get; set; }

        public string Observacao {get; set; }

        public DateTime DtSituacao {get; set; }

        public string Usuario {get; set; }

        public string UsuarioAtualizacao {get; set; }
        
        public DateTime DataAtualizacao {get; set; }

        public PropostaModelo(PropostaDominio dominio)
        {
            Id = dominio.Id;
            Proposta = dominio.Proposta;
            Cpf = dominio.Cpf;
            Conveniada = dominio.Conveniada;
            VlrSolicitado = dominio.VlrSolicitado;
            Prazo = dominio.Prazo;
            VlrFinanciado = dominio.VlrFinanciado;
            Situacao = dominio.Situacao;
            Observacao = dominio.Observacao;
            DtSituacao = dominio.DtSituacao;
            Usuario = dominio.Usuario;
            UsuarioAtualizacao = dominio.UsuarioAtualizacao;
            DataAtualizacao = dominio.DataAtualizacao;
        }
    }
}