using System;

namespace Dominio.Entidade
{
    public class LimiteIdadeConveniadaDominio
    {
        public int Id {get; private set; }

        public char Conveniada {get; private set; }

        public decimal IdadeInicial {get; private set; }

        public decimal IdadeFinal {get; private set; }

        public decimal ValorLimite {get; private set; }

        public decimal PercentualMaximo {get; private set; }

        public char UsuarioAtualizacao {get; private set; }

        public DateTime DataAtualizacao {get; private set; }

    }
}