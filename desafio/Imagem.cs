using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
     class Imagem
    {
        private static String  imagemP;
        private static String imagemB;



        public static void setImagemP(String _imagemP) { imagemP = _imagemP; }
        public static void setImagemB(String _imagemB) { imagemB = _imagemB; }


        public String getImagemP() { return imagemP; }
        public String getImagemB() { return imagemB; }
    }
}
