using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    class TelaDoSiteTextos
    {
        private static String nomeUsuario;
        private static String texto;
        private static String imagem;





        public static void setNomeUsuario(String _nomeUsuario) { nomeUsuario = _nomeUsuario; }
        public static void setTexto(String _texto) { texto = _texto; }
        public static void setImagem(String _imagem) { imagem = _imagem; }
        public static void limpaTudo()
        {
            nomeUsuario = "";
            texto = "";
            imagem = "";

        }



        public static String getNomeUsuario() { return nomeUsuario; }
        public static String getTexto() { return texto; }

        public static String getImagem() { return imagem; }


    }
}
