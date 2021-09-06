using System.ComponentModel.DataAnnotations;

namespace Aplicacao.Modelo.Login
{
    public class LoginEnvioModelo
    {
        [Required(ErrorMessage = "O usuario não pode vazio.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "A senha não pode vazio.")]
        public string Senha { get; set; }
    }
}