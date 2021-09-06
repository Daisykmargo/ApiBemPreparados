using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Modelo.Usuario;
using Aplicacao.Servico.Interface;
using Dominio.Entidade;
using Infraestrutura.Repositorio;

namespace Aplicacao.Servico
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        public UsuarioServico(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        
        public async Task<string> ValidarLogin(string usuario, string senha)
        {
            var retornoValidacao = await _usuarioRepositorio.ValidarLogin(usuario,senha);
            return retornoValidacao;
        }      

    }
}