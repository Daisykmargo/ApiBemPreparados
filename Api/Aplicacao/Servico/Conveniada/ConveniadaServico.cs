using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Aplicacao.Modelo.Cep;
using Aplicacao.Modelo.Conveniada;
using Aplicacao.Servico.Interface;
using Infraestrutura.Repositorio;

namespace Aplicacao.Servico
{
    public class ConveniadaServico : IConveniadaServico
    {
        private readonly IConveniadaRepositorio _conveniadaRepositorio;
        public ConveniadaServico(IConveniadaRepositorio conveniadaRepositorio)
        {
            _conveniadaRepositorio = conveniadaRepositorio;
        }

        
        public async Task<IEnumerable<ConveniadaModelo>> BuscarConveniada()
        {
            var conveniadas = await _conveniadaRepositorio.BuscarConveniada();

            return conveniadas.Select(conveniada => new ConveniadaModelo(conveniada));
        }
        
    }
}