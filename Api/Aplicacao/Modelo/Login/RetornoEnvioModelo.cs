namespace Aplicacao.Modelo.Login
{
    public class RetornoEnvioModelo{
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }
    }
}