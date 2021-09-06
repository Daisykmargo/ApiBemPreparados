using System;

namespace Dominio.Entidade
{
    public class SituacaoDominio
    {
        public int Id {get; private set; }

        public string Situacao {get; private set; }

        public string Descricao {get; private set; }

        public char UsuarioAtualizacao {get; private set; }

        public DateTime DataAtualizacao {get; private set; }
        
    }
}