using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    class NovoPost
    {
        private String texto;
        public static string  image;





        public void setTexto(String _texto) { texto = _texto; }
        public void setImage(String _image) { image = _image; }



        public String getTexto() { return texto; }
        public String getImage(){ return image; }




        }
}
