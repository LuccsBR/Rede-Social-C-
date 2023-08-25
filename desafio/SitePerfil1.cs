using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
     class SitePerfil1
    {
        private static String email;
        private static String nomeUsuario;
        private static String texto;





        public  void setNomeUsuario(String _nomeUsuario) { nomeUsuario = _nomeUsuario; }
        public static void setTexto(String _texto) { texto = _texto; }



      


        public void setEmail(String _email) { email = _email; }



        public String getEmail() { return email; }
        public  String getNomeUsuario() { return nomeUsuario; }
        public static String getTexto() { return texto; }
    }
}
