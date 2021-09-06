using System;
using System.Net;
using System.Threading.Tasks;
using Aplicacao.Modelo.Login;
using Aplicacao.Servico.Interface;
using Aplicacao.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Api.Controllers
{
 
        [ApiController]
        [Route("login")]
        [AllowAnonymous]
        
        public class AuthController: ControllerBase {
        private readonly IConfiguration _configuration;
        private readonly ITokenGerador _tokenGenerator;

        private readonly IUsuarioServico _usuarioServico;

        public AuthController(IConfiguration configuration, ITokenGerador tokenGerador, IUsuarioServico usuarioServico)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGerador;
            _usuarioServico = usuarioServico;
        }

        
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginEnvioModelo loginEnvioModelo){
            try
            {
                var retornoValidacao = await _usuarioServico.ValidarLogin(loginEnvioModelo.Usuario, loginEnvioModelo.Senha);

                if (retornoValidacao == "Usuário Válido")
                {
                   
                    return Ok(new RetornoEnvioModelo
                    {
                        Message = "Usuário autenticado com sucesso!",
                        Success = true,
                        Data = new
                        {
                            Token = _tokenGenerator.GenerateToken(loginEnvioModelo),
                            TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                        }
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.Unauthorized, new RetornoEnvioModelo 
                    { 
                        Message = retornoValidacao,
                        Success = false
                        
                    });
                }
                
            }
            catch(Exception ex)
            {
              return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
