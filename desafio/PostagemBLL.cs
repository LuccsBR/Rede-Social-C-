using ParaCasa1;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    class PostagemBLL
    {
        public static int[] data()
        {
            var date = DateTime.Now;
            int[] data = new int[3];
            data[0] = date.Day;
            data[1] = date.Month;
            data[2] = date.Year;
            return data;


        }

        public static void conecta()
        {
            PostagemDAL.conecta();
        }

        public static void desconecta()
        {
            PostagemDAL.desconecta();
        }

        public static void validaDados(NovoPost umPost)
        {
            Erro.setErro(false);
            if (umPost.getTexto().Equals(""))
            {
                Erro.setMsg("O Texto é de preenchimento obrigatório!");
                return;
            }
            PostagemDAL.inseriUmCadastro1(umPost);




        }
        public static void populaDR()
        {
            PostagemDAL.populaDR();
        }
        public static void populaDRS()
        {
            PostagemDAL.populaDRS();
        }
        public static void getProximo()
        {
            PostagemDAL.getProximo();
        }
        public static void getProximoS()
        {
            PostagemDAL.getProximoS();
        }
        public byte[] GetFoto(string caminhoFoto)
        {
            byte[] foto;
            using (var stream = new FileStream(caminhoFoto, FileMode.Open, FileAccess.Read))

            {

                using (var reader = new BinaryReader(stream))

                {
                    foto = reader.ReadBytes((int)stream.Length);

                }

                return foto;

            }
        }
    }
}
