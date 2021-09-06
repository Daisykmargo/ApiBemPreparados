using System;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infraestrutura.Repositorio
{
    public class CalculoPropostaRepositorio : RepositorioBase, ICalculoPropostaRepositorio
    {
        public CalculoPropostaRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<decimal> BuscarJuros()
        {

            try
            {
                // Abre a conexão com o banco de dados
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT TOP 1 TAXA_JUROS
                                FROM TREINA_DETALHES
                                ORDER BY ID DESC";


                return await _connection.ExecuteScalarAsync<decimal>(query);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao buscar taxa de juros. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

        }

    }
}