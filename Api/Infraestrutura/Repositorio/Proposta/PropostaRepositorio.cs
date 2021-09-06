using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Dominio.Entidade;
using Microsoft.Extensions.Configuration;

namespace Infraestrutura.Repositorio
{
    public class PropostaRepositorio : RepositorioBase, IPropostaRepositorio
    {
        public PropostaRepositorio(IConfiguration configuration) : base(configuration) { }

        public async Task<PropostaDominio> ObterProposta(int id)
        {
            PropostaDominio proposta = null;
            try
            {
                _connection.Open();
                var query = @"SELECT 
                                    ID_TREINA_PROPOSTA as Id,
                                    PROPOSTA,
                                    CPF,
                                    CONVENIADA,
                                    VLR_SOLICITADO as VlrSolicitado,
                                    PRAZO,
                                    VLR_FINANCIADO as VlrFinanciado,
                                    SITUACAO,
                                    OBSERVACAO,
                                    DT_SITUACAO as DtSituacao,
                                    USUARIO,
                                    USUARIO_ATUALIZACAO as UsuarioAtualizacao,
                                    DATA_ATUALIZACAO as DataAtualizacao
                                FROM TREINA_PROPOSTAS 
                                WHERE ID_TREINA_PROPOSTA = @id";


                var parametro = new DynamicParameters();
                parametro.Add("id", id);

                proposta = await _connection.QueryFirstOrDefaultAsync<PropostaDominio>(query, parametro);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao obter a proposta id {id}. Detalhes: {ex.Message}");

            }
            finally
            {
                _connection.Close();
            }

            return proposta;
        }

        public async Task<IEnumerable<PropostaDominio>> BuscarProposta()
        {
            // Apenas cria uma lista para ser utilizada para retorno das propostas
            IEnumerable<PropostaDominio> proposta = null;
            try
            {
                // Abre a conexão com o banco de dados
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT 
                                    ID_TREINA_PROPOSTA as Id,
                                    PROPOSTA,
                                    CPF,
                                    CONVENIADA,
                                    VLR_SOLICITADO as VlrSolicitado,
                                    PRAZO,
                                    VLR_FINANCIADO as VlrFinanciado,
                                    SITUACAO,
                                    OBSERVACAO,
                                    DT_SITUACAO as DtSituacao,
                                    USUARIO,
                                    USUARIO_ATUALIZACAO as UsuarioAtualizacao,
                                    DATA_ATUALIZACAO as DataAtualizacao
                                FROM TREINA_PROPOSTAS";

                proposta = await _connection.QueryAsync<PropostaDominio>(query);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao buscar a proposta. Detalhes: {ex.Message}");

            }
            finally
            {
                // Fecha a conexão com o banco de dados
                _connection.Close();
            }

            return proposta;
        }

        public async Task<PropostaDominio> GravarProposta(PropostaDominio proposta)
        {
            PropostaDominio novaProposta = null;
            try
            {
                _connection.Open();
                var query = @"INSERT INTO TREINA_PROPOSTAS 
                (                   
                                    PROPOSTA,
                                    CPF,
                                    CONVENIADA,
                                    VLR_SOLICITADO,
                                    PRAZO,
                                    VLR_FINANCIADO,
                                    SITUACAO,
                                    OBSERVACAO,
                                    DT_SITUACAO,
                                    USUARIO,
                                    USUARIO_ATUALIZACAO,
                                    DATA_ATUALIZACAO
                                    
                    ) 
                    VALUES 
                    (
                                    @PROPOSTA,
                                    @CPF,
                                    @CONVENIADA,
                                    @VLRSOLICITADO,
                                    @PRAZO,
                                    @VLRFINANCIADO,
                                    @SITUACAO,
                                    @OBSERVACAO,
                                    @DTSITUACAO,
                                    @USUARIO,
                                    @USUARIOATUALIZACAO,
                                    @DATAATUALIZACAO
                
                        ); 

                        SELECT 
                                    ID_TREINA_PROPOSTA as Id,
                                    PROPOSTA,
                                    CPF,
                                    CONVENIADA,
                                    VLR_SOLICITADO as VlrSolicitado,
                                    PRAZO,
                                    VLR_FINANCIADO as VlrFinanciado,
                                    SITUACAO,
                                    OBSERVACAO,
                                    DT_SITUACAO as DtSituacao,
                                    USUARIO,
                                    USUARIO_ATUALIZACAO as UsuarioAtualizacao,
                                    DATA_ATUALIZACAO as DataAtualizacao
                                FROM TREINA_PROPOSTAS 
                                WHERE ID_TREINA_PROPOSTA = CAST(SCOPE_IDENTITY() as INT);";


                // _connection.QueryFirstAsync (first == primeiro em inglês) retorna somente o primeiro registro de uma consulta
                novaProposta = await _connection.QueryFirstAsync<PropostaDominio>(query, proposta);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao gravar a proposta {proposta.Id}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return novaProposta;
        }

        public async Task<bool> AtualizarProposta(int id, PropostaDominio propostaAtualizacao)
        {
            var registrosAtualizados = 0;
            try
            {
                _connection.Open();
                var query = @"UPDATE TREINA_PROPOSTAS SET 
                                    PROPOSTA = @proposta,
                                    CPF = @cpf,
                                    CONVENIADA = @conveniada,
                                    VLR_SOLICITADO = @vlrSolicitado,
                                    PRAZO = @prazo,
                                    VLR_FINANCIADO = @vlrFinanciado,
                                    SITUACAO = @situacao,
                                    OBSERVACAO = @observacao,
                                    DT_SITUACAO = @dtSituacao,
                                    USUARIO = @usuario,
                                    USUARIO_ATUALIZACAO = @usuarioAtualizacao,
                                    DATA_ATUALIZACAO = @dataAtualizacao
                                WHERE ID_TREINA_PROPOSTA = @id";


                var parametros = new DynamicParameters();
                parametros.Add("id", id);
                parametros.Add("proposta", propostaAtualizacao.Proposta);
                parametros.Add("cpf", propostaAtualizacao.Cpf);
                parametros.Add("conveniada", propostaAtualizacao.Conveniada);
                parametros.Add("vlrSolicitado", propostaAtualizacao.VlrSolicitado);
                parametros.Add("prazo", propostaAtualizacao.Prazo);
                parametros.Add("vlrFinanciado", propostaAtualizacao.VlrFinanciado);
                parametros.Add("situacao", propostaAtualizacao.Situacao);
                parametros.Add("observacao", propostaAtualizacao.Observacao);
                parametros.Add("dtSituacao", propostaAtualizacao.DtSituacao);
                parametros.Add("usuario", propostaAtualizacao.Usuario);
                parametros.Add("usuarioAtualizacao", propostaAtualizacao.UsuarioAtualizacao);
                parametros.Add("dataAtualizacao", propostaAtualizacao.DataAtualizacao);

                // _connection.ExecuteAsync apenas executa o comando SQL que passamos, e retorna a quantidade de registro que afetou
                registrosAtualizados = await _connection.ExecuteAsync(query, parametros);

                if (registrosAtualizados == 0)
                    throw new ArgumentException($"Nenhum registro pôde ser atualizado.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao atualizar a proposta id {id}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return registrosAtualizados == 1;
        }

        public async Task<decimal> ObterProximoNumeroProposta()
        {

            try
            {
                // Abre a conexão com o banco de dados
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT MAX (PROPOSTA) + 1
                                FROM TREINA_PROPOSTAS";


                return await _connection.ExecuteScalarAsync<decimal>(query);

            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao encrementar proposta. Detalhes: { ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

        }
    }
}