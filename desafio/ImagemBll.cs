using ParaCasa1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    class ImagemBll
    {
        public static void enviaFBanner(Imagem umCadastro)
        {

            ImagemDAL.inseriBanner(umCadastro);

        }
        public static void enviaFPerfil(Imagem umCadastro)
        {
            if (umCadastro.getImagemP().Equals(""))
            {
                return;
            }
            ImagemDAL.inseriPerfil(umCadastro);

        }
    }
}
        
