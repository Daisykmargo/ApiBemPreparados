using System;
using Dominio.Entidade;

namespace Aplicacao.Modelo.Conveniada
{
    public class ConveniadaModelo
    {
        public int Id { get; set; }

        public string Conveniada { get; set; }

        public string Descricao { get; set; }

        public string UsuarioAtualizacao { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public ConveniadaModelo(ConveniadaDominio dominio)
        {
            Id = dominio.Id;
            Conveniada = dominio.Conveniada;
            Descricao = dominio.Descricao;
            UsuarioAtualizacao = dominio.UsuarioAtualizacao;
            DataAtualizacao = dominio.DataAtualizacao;
        }

    }
}