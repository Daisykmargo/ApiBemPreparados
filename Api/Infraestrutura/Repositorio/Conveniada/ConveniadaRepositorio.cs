using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dominio.Entidade;
using Microsoft.Extensions.Configuration;


namespace Infraestrutura.Repositorio
{
    public class ConveniadaRepositorio : RepositorioBase, IConveniadaRepositorio
    {
        public ConveniadaRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<IEnumerable<ConveniadaDominio>> BuscarConveniada()
        {
            IEnumerable<ConveniadaDominio> conveniada = null;
            try
            {
                _connection.Open();

                var query = @"SELECT 
                                    ID_TREINA_CONVENIADA as Id,
                                    CONVENIADA,
                                    DESCRICAO,
                                    USUARIO_ATUALIZACAO as UsuarioAtualizacao,
                                    DATA_ATUALIZACAO as DataAtualizacao
                                FROM TREINA_CONVENIADAS";

                conveniada = await _connection.QueryAsync<ConveniadaDominio>(query);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao buscar a conveniada. Detalhes: {ex.Message}");

            }
            finally
            {

                _connection.Close();
            }

            return conveniada;
        }
    }
}
