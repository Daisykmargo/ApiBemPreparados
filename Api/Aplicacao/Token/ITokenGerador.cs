using Aplicacao.Modelo.Login;

namespace Aplicacao.Token
{
    public interface ITokenGerador
    {
        string GenerateToken(LoginEnvioModelo loginEnvioModelo);
    }
}