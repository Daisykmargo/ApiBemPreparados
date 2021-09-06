using System.Threading.Tasks;
using Aplicacao.Modelo.Cep;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("ceps")]
    [AllowAnonymous]
    public class CepController : ControllerBase
    {
        private readonly ICepServico _cepServico;

        public CepController(ICepServico cepServico)
        {
            _cepServico = cepServico;
        }

        [HttpGet("{cep}")]
        public async Task<CepModelo>Get([FromRoute] string cep)
        {
            var ceps = await _cepServico.BuscarCep(cep);
            return ceps;
        }
    }
}