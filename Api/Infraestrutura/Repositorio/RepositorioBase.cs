using System;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Infraestrutura.Repositorio
{
    public abstract class RepositorioBase : IDisposable
    {
        protected readonly IConfiguration _configuration;
        //protected readonly IMensagemRetorno _mensagens;
        protected readonly SqlConnection _connection;

        public RepositorioBase(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = getConnection();
        }

        private SqlConnection getConnection()
        {
            var connectionString = _configuration.GetSection("ConnectionString")
                                .GetSection("DaisyConnection").Value;

            return new SqlConnection(connectionString); ;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}