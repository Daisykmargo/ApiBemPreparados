using Aplicacao.Servico;
using Aplicacao.Servico.Interface;
using Aplicacao.Token;
using Infraestrutura.Repositorio;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao.IoC
{
    public static class IoC
    {
        public static IServiceCollection ConfigurarDependencias(this IServiceCollection servico)
        {
            servico.AddTransient<IClienteServico, ClienteServico>();
            servico.AddTransient<IClienteRepositorio, ClienteRepositorio>();
            servico.AddTransient<IUsuarioServico, UsuarioServico>();
            servico.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            servico.AddTransient<ITokenGerador, TokenGerador>();
            servico.AddTransient<ICepServico, CepServico>();
            servico.AddTransient<IConveniadaServico, ConveniadaServico>();
            servico.AddTransient<IConveniadaRepositorio, ConveniadaRepositorio>();
            servico.AddTransient<IPropostaServico, PropostaServico>();
            servico.AddTransient<IPropostaRepositorio, PropostaRepositorio>();
            servico.AddTransient<ICalculoPropostaRepositorio, CalculoPropostaRepositorio>();
            



            return servico;
        }


    }
}