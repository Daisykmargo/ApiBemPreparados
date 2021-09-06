using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using Aplicacao.Modelo.Proposta;
using Aplicacao.Servico.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("propostas")]
    [Authorize]
    public class PropostaController : ControllerBase
    {

        private readonly IPropostaServico _propostaServico;

        public PropostaController(IPropostaServico propostaServico)
        {
            _propostaServico = propostaServico;
        }

        [HttpGet]
        public async Task<IEnumerable<PropostaModelo>> Get()
        {
            var propostas = await _propostaServico.BuscarProposta();
            return propostas;
        }

        [HttpPost]
        public async Task<PropostaModelo> Post([FromBody] PropostaEnvioModelo proposta)
        {
            proposta.Usuario = obterUsuarioToken();
            var novaProposta = await _propostaServico.CriarProposta(proposta);
            return novaProposta;
        }

        [HttpPut("{idProposta}")]
        public async Task<PropostaModelo> Put([FromRoute] int idProposta, [FromBody] PropostaEnvioModelo proposta)
        {
            var propostaAtualizado = await _propostaServico.AtualizarProposta(idProposta, proposta);
            return propostaAtualizado;
        }

        [HttpGet("calculos-financiamento")]
        public async Task<decimal> CalcularValorFinanciado([Required] decimal vlrSolicitado, [Required] int prazo)
        {
            var valorFinanciado = await _propostaServico.CalcularFinanciamento(vlrSolicitado, prazo);
            return valorFinanciado;
        }

        private string obterUsuarioToken()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var user = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                return user;
            }
            throw new ArgumentException("Token não possui informação do usuário.");
        }
    }
}