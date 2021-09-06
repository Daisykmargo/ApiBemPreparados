using System;
using Dominio.Entidade;

namespace Aplicacao.Modelo.Proposta
{
    public class PropostaEnvioModelo
    {
        public decimal Proposta {get; set; }
        public string Cpf {get; set; }

        public string Conveniada {get; set; }

        public decimal VlrSolicitado {get; set; }

        public int Prazo {get; set; }

        public decimal VlrFinanciado {get; set; }

        public string Situacao {get; set; }

        public string Observacao {get; set; }

        public string Usuario {get; set; }

        public string UsuarioAtualizacao {get; set; }
        
    }
}