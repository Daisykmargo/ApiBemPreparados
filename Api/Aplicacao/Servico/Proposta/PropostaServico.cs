using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Modelo.Cliente;
using Aplicacao.Modelo.Proposta;
using Aplicacao.Servico.Interface;
using Dominio.Entidade;
using Infraestrutura.Repositorio;

namespace Aplicacao.Servico
{
    public class PropostaServico : IPropostaServico
    {
        private readonly IPropostaRepositorio _propostaRepositorio;
        private readonly ICalculoPropostaRepositorio _calculoPropostaRepositorio;
        public PropostaServico(IPropostaRepositorio propostaRepositorio, ICalculoPropostaRepositorio calculoPropostaRepositorio)
        {
            _propostaRepositorio = propostaRepositorio;
            _calculoPropostaRepositorio = calculoPropostaRepositorio;
        }


        public async Task<IEnumerable<PropostaModelo>> BuscarProposta()
        {
            var proposta = await _propostaRepositorio.BuscarProposta();

            return proposta.Select(proposta => new PropostaModelo(proposta));
        }
        public async Task<PropostaModelo> CriarProposta(PropostaEnvioModelo proposta)
        {
             ValidarPrazo(proposta.Prazo);
            
            var propostas = new PropostaDominio(

                await _propostaRepositorio.ObterProximoNumeroProposta(),
                proposta.Cpf,
                proposta.Conveniada,
                proposta.VlrSolicitado,
                proposta.Prazo,
                proposta.VlrFinanciado,
                proposta.Situacao,
                proposta.Observacao,
                proposta.Usuario,
                proposta.UsuarioAtualizacao
            );

            var novaProposta = await _propostaRepositorio.GravarProposta(propostas);
            //_mensagens.SetHttpStatus(HttpStatusCode.Created);

            return new PropostaModelo(novaProposta);
        }

        public async Task<PropostaModelo> AtualizarProposta(int idProposta, PropostaEnvioModelo propostaAtualizacao)
        {
            var proposta = await _propostaRepositorio.ObterProposta(idProposta);

            if (proposta == null)
            {
                throw new ArgumentException($"Nenhum registro localizado com id {idProposta}.");

            }

            proposta.AtualizarProposta(


                propostaAtualizacao.Conveniada,
                propostaAtualizacao.VlrSolicitado,
                propostaAtualizacao.Prazo,
                propostaAtualizacao.VlrFinanciado,
                propostaAtualizacao.Situacao,
                propostaAtualizacao.Usuario,
                propostaAtualizacao.UsuarioAtualizacao

                );

            await _propostaRepositorio.AtualizarProposta(idProposta, proposta);

            return new PropostaModelo(proposta);
        }

        public async Task<decimal> CalcularFinanciamento(decimal vlrSolicitado, int prazo)
        {
            ValidarPrazo(prazo);

            var taxa = await _calculoPropostaRepositorio.BuscarJuros(); //obter taxa

            var valorFinal = Convert.ToDouble(vlrSolicitado) * Math.Pow(1 + Convert.ToDouble(taxa), Convert.ToDouble(prazo));//coverte dec. p double
            return (decimal)Math.Truncate(100 * valorFinal) / 100;
        }

       
        private void ValidarPrazo(int prazo)
        {
            if (prazo < 1 || prazo > 99)
            {
                throw new ArgumentException("Prazo deve ser de 1 á 99  meses");
            }
        }

       
    }
}