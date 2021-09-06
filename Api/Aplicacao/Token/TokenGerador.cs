using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aplicacao.Modelo.Login;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Aplicacao.Token
{
    public class TokenGerador : ITokenGerador
    {
        private readonly IConfiguration _configuration;

        public TokenGerador(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(LoginEnvioModelo loginEnvioModelo)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, _configuration["Jwt:Login"]),
                    new Claim(ClaimTypes.NameIdentifier, loginEnvioModelo.Usuario),
                    //new Claim(ClaimTypes.Role, "User")
                }),
                Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"])),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}