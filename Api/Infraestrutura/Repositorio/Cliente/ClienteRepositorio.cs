using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Dominio.Entidade;
using Dapper;
using System.Net;

namespace Infraestrutura.Repositorio
{
    public class ClienteRepositorio : RepositorioBase, IClienteRepositorio
    {
        public ClienteRepositorio(IConfiguration configuration) : base(configuration) {}

        public async Task<ClienteDominio> ObterCliente(string cpf)
        {
            ClienteDominio cliente = null;
            try
            {
                _connection.Open();
                var query = @"SELECT 
                                    ID_TREINA_CLIENTE as Id,
                                    CPF,
                                    NOME,
                                    DT_NASCIMENTO as DtNascimento,
                                    GENERO,
                                    VLR_SALARIO as VlrSalario,
                                    LOGRADOURO,
                                    NUMERO_RESIDENCIA as NumeroResidencia,
                                    BAIRRO,
                                    CIDADE,
                                    CEP,
                                    USUARIO_ATUALIZACAO as UsuarioAtualizacao,
                                    DATA_ATUALIZACAO as DataAtualizacao
                                FROM TREINA_CLIENTES 
                                WHERE CPF = @cpf";
 

                var parametro = new DynamicParameters();
                parametro.Add("cpf", cpf);

                cliente = await _connection.QueryFirstOrDefaultAsync<ClienteDominio>(query, parametro);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao obter o cliente cpf {cpf}. Detalhes: {ex.Message}");
            
            }
            finally
            {
                _connection.Close();
            }

            return cliente;
        }

        public async Task<IEnumerable<ClienteDominio>> BuscarCliente()
        {
            // Apenas cria uma lista para ser utilizada para retorno dos clientes
            IEnumerable<ClienteDominio> cliente = null;
            try
            {
                // Abre a conexão com o banco de dados
                _connection.Open();
                // Cria uma variável, colocando dentro dela a string SQL da consulta no banco de dados
                var query = @"SELECT 
                                    ID_TREINA_CLIENTE as Id,
                                    CPF,
                                    NOME,
                                    DT_NASCIMENTO as DtNascimento,
                                    GENERO,
                                    VLR_SALARIO as VlrSalario,
                                    LOGRADOURO,
                                    NUMERO_RESIDENCIA as NumeroResidencia,
                                    BAIRRO,
                                    CIDADE,
                                    CEP,
                                    USUARIO_ATUALIZACAO as UsuarioAtualizacao,
                                    DATA_ATUALIZACAO as DataAtualizacao
                                FROM TREINA_CLIENTES";
               
                cliente = await _connection.QueryAsync<ClienteDominio>(query);
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao buscar o cliente. Detalhes: {ex.Message}");
                
            }
            finally
            {
                // Fecha a conexão com o banco de dados
                _connection.Close();
            }

            return cliente;
        }

        public async Task<ClienteDominio> GravarCliente(ClienteDominio cliente)
        {
            ClienteDominio novoCliente = null;
            try
            {
                _connection.Open();
                var query = @"INSERT INTO TREINA_CLIENTES 
                (
                                    CPF,
                                    NOME,
                                    DT_NASCIMENTO,
                                    GENERO,
                                    VLR_SALARIO,
                                    LOGRADOURO,
                                    NUMERO_RESIDENCIA,
                                    BAIRRO,
                                    CIDADE,
                                    CEP,
                                    USUARIO_ATUALIZACAO,
                                    DATA_ATUALIZACAO

                    ) 
                    VALUES 
                    (
                        @cpf, 
                        @nome, 
                        @dtNascimento, 
                        @genero, 
                        @VlrSalario, 
                        @Logradouro, 
                        @NumeroResidencia,
                        @Bairro, 
                        @cidade, 
                        @Cep, 
                        @UsuarioAtualizacao, 
                        @DataAtualizacao

                        ); 

                        SELECT 
                                    ID_TREINA_CLIENTE as Id,
                                    CPF,
                                    NOME,
                                    DT_NASCIMENTO as DtNascimento,
                                    GENERO,
                                    VLR_SALARIO as VlrSalario,
                                    LOGRADOURO,
                                    NUMERO_RESIDENCIA as NumeroResidencia,
                                    BAIRRO,
                                    CIDADE,
                                    CEP,
                                    USUARIO_ATUALIZACAO as UsuarioAtualizacao,
                                    DATA_ATUALIZACAO as DataAtualizacao
                            FROM TREINA_CLIENTES 
                            WHERE ID_TREINA_CLIENTE = CAST(SCOPE_IDENTITY() as INT);";
                        
                // _connection.QueryFirstAsync (first == primeiro em inglês) retorna somente o primeiro registro de uma consulta
                novoCliente = await _connection.QueryFirstAsync<ClienteDominio>(query, cliente);
            }
            catch (Exception ex)
            {
               throw new ArgumentException($"Ocorreu um erro ao gravar o cliente {cliente.Nome}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return novoCliente;
        }

        public async Task<bool> AtualizarCliente(string cpf, ClienteDominio clienteAtualizacao)
        {
            var registrosAtualizados = 0;
            try
            {
                _connection.Open();
                var query = @"UPDATE TREINA_CLIENTES SET 
                                        NOME = @nome, 
                                        DT_NASCIMENTO = @dtNascimento, 
                                        GENERO = @genero, 
                                        VLR_SALARIO = @vlrSalario, 
                                        LOGRADOURO = @logradouro, 
                                        NUMERO_RESIDENCIA = @numeroResidencia, 
                                        BAIRRO = @bairro, 
                                        CIDADE = @cidade, 
                                        CEP = @cep, 
                                        USUARIO_ATUALIZACAO = @usuarioAtualizacao, 
                                        DATA_ATUALIZACAO = @dataAtualizacao 
                                        WHERE CPF = @cpf";

                var parametros = new DynamicParameters();
                parametros.Add("cpf",cpf);
                parametros.Add("nome", clienteAtualizacao.Nome);
                parametros.Add("dtNascimento", clienteAtualizacao.DtNascimento);
                parametros.Add("genero", clienteAtualizacao.Genero);
                parametros.Add("vlrSalario", clienteAtualizacao.VlrSalario);
                parametros.Add("logradouro", clienteAtualizacao.Logradouro);
                parametros.Add("numeroResidencia", clienteAtualizacao.NumeroResidencia);
                parametros.Add("bairro", clienteAtualizacao.Bairro);
                parametros.Add("cidade", clienteAtualizacao.Cidade);
                parametros.Add("cep", clienteAtualizacao.Cep);
                parametros.Add("usuarioAtualizacao", clienteAtualizacao.UsuarioAtualizacao);
                parametros.Add("dataAtualizacao", clienteAtualizacao.DataAtualizacao);

                // _connection.ExecuteAsync apenas executa o comando SQL que passamos, e retorna a quantidade de registro que afetou
                registrosAtualizados = await _connection.ExecuteAsync(query, parametros);

                if (registrosAtualizados == 0)
                    throw new ArgumentException($"Nenhum registro pôde ser atualizado.");
            }
            catch (Exception ex)
            {
               throw new ArgumentException($"Ocorreu um erro ao atualizar o cliente cpf {cpf}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return registrosAtualizados == 1;
        }

        public async Task<bool> DeletarCliente(string cpf)
        {
            var registrosDeletados = 0;
            try
            {
                _connection.Open();
                var query = @"DELETE FROM TREINA_CLIENTES WHERE ID_TREINA_CLIENTE = @id";

                var parametro = new DynamicParameters();
                parametro.Add("cpf", cpf);

                registrosDeletados = await _connection.ExecuteAsync(query, parametro);

                if (registrosDeletados == 0)

                   throw new ArgumentException($"Nenhum registro pôde ser deletado.");
            }
            catch (Exception ex)
            {
                throw new ArgumentException($"Ocorreu um erro ao deletar o cliente cpf {cpf}. Detalhes: {ex.Message}");
            }
            finally
            {
                _connection.Close();
            }

            return registrosDeletados == 1;
        }
    }
}