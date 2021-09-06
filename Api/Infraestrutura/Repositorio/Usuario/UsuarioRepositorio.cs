using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Dominio.Entidade;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Infraestrutura.Repositorio
{
    public class UsuarioRepositorio : RepositorioBase, IUsuarioRepositorio
    {
        public UsuarioRepositorio(IConfiguration configuration) : base(configuration) { }

            public async Task<string> ValidarLogin(string usuario, string senha)
        {
            var usuarioValidado = "";
            try
            {
                // Abre a conexão com o banco de dados
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT dbo.F_VALIDAR_LOGIN(@USUARIO, @SENHA)"; 
                                
                var parametros = new DynamicParameters();
                parametros.Add("@USUARIO",usuario);
                parametros.Add("@SENHA",senha);
               
                usuarioValidado = await _connection.QueryFirstOrDefaultAsync<string>(query, parametros);

                if (string.IsNullOrWhiteSpace(usuarioValidado))//verifica se o usuario validado é nulo ou espaço branco
                    throw new ArgumentException($"Nenhum registro pôde ser validado.");
            }
            catch (Exception ex)
            {
               throw new ArgumentException($"Ocorreu um erro ao validar usuario {usuario}, senha {senha}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return usuarioValidado;
        }

    }
}