using Aplicacao.Modelo.Conveniada;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

 namespace Api.Controllers
{
    [ApiController]
    [Route("conveniadas")]
    [AllowAnonymous]
    public class ConveniadaController : ControllerBase
    {
        private readonly IConveniadaServico _conveniadaServico;

        public ConveniadaController(IConveniadaServico conveniadaServico)
        {
            _conveniadaServico = conveniadaServico;
        }

        [HttpGet]
        public async Task<IEnumerable<ConveniadaModelo>> Get()
        {
            var conveniadas = await _conveniadaServico.BuscarConveniada();
            return conveniadas;
        }
    }
}
