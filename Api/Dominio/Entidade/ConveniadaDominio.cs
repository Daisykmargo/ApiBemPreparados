using System;

namespace Dominio.Entidade
{
    public class ConveniadaDominio
    {
        public int Id {get; private set; }

        public string Conveniada {get; private set; }

        public string Descricao {get; private set; }

        public string UsuarioAtualizacao {get; private set; }

        public DateTime DataAtualizacao {get; private set; }

    }
}