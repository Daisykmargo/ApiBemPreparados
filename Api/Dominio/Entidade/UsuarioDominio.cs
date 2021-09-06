using System;

namespace Dominio.Entidade
{
    public class UsuarioDominio
    {
        public string Usuario {get; set; }

        public string Senha {get; set; }

        protected  UsuarioDominio(){} 

                //Metodo construtor
        public UsuarioDominio(

            string usuario,
            string senha 
           
            )
        {
                Usuario = usuario;
                Senha = senha;
                
        }
                        
    }

}
  