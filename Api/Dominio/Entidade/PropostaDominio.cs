using System;

namespace Dominio.Entidade
{
    public class PropostaDominio
    {
        public int Id { get; private set; }

        public decimal Proposta { get; private set; }

        public string Cpf { get; private set; }

        public string Conveniada { get; private set; }

        public decimal VlrSolicitado { get; private set; }

        public decimal Prazo { get; private set; }

        public decimal VlrFinanciado { get; private set; }

        public string Situacao { get; private set; }

        public string Observacao { get; private set; }

        public DateTime DtSituacao { get; private set; }

        public string Usuario { get; private set; }

        public string UsuarioAtualizacao { get; private set; }

        public DateTime DataAtualizacao { get; private set; }


        protected PropostaDominio() { }

        //Metodo construtor
        public PropostaDominio(

            decimal proposta,
            string cpf,
            string conveniada,
            decimal vlrSolicitado,
            decimal prazo,
            decimal vlrFinanciado,
            string situacao,
            string observacao,
            string usuario,
            string usuarioAtualizacao

            )
        {
            Proposta = proposta;
            Cpf = cpf;
            Conveniada = conveniada;
            VlrSolicitado = vlrSolicitado;
            Prazo = prazo;
            VlrFinanciado = vlrFinanciado;
            Situacao = situacao;
            Observacao = observacao;
            DtSituacao = DateTime.Now;
            Usuario = usuario;
            UsuarioAtualizacao = usuarioAtualizacao;
            DataAtualizacao = DateTime.Now;
        }

        public void AtualizarProposta(

            string conveniada,
            decimal vlrSolicitado,
            decimal prazo,
            decimal vlrFinanciado,
            string situacao,
            string usuario,
            string usuarioAtualizacao

            )
        {
            Conveniada = conveniada;
            VlrSolicitado = vlrSolicitado;
            Prazo = prazo;
            VlrFinanciado = vlrFinanciado;
            Situacao = situacao;
            Usuario = usuario;
            UsuarioAtualizacao = usuarioAtualizacao;
            DataAtualizacao = DateTime.Now;


        }

    }
}