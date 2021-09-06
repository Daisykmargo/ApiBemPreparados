using System.Collections.Generic;
using Aplicacao.Modelo.Login;

namespace Api.Utlidades
{
    public static class Responses{
        public static RetornoEnvioModelo ApplicationErrorMessage()
        {
            return new RetornoEnvioModelo
            {
                Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente.",
                Success = false,
                Data = null
            };
        }

        public static RetornoEnvioModelo DomainErrorMessage(string message)
        {
            return new RetornoEnvioModelo
            {
                Message = message,
                Success = false,
                Data = null
            };
        }

        public static RetornoEnvioModelo DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new RetornoEnvioModelo
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }

        public static RetornoEnvioModelo UnauthorizedErrorMessage()
        {
            return new RetornoEnvioModelo
            {
                Message = "A combinação de login e senha está incorreta!",
                Success = false,
                Data = null
            };
        }
    }
}