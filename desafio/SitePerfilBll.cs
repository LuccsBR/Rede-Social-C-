using ParaCasa1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    class SitePerfilBll
    {
        public static void validaEmail(SitePerfil1 umPost)
        {
            Erro.setErro(false);
            if (umPost.getEmail().Equals(""))
            {
                Erro.setMsg("Error");
                return;
            }
            SitePerfilDAL.devolverPerfil(umPost);
        }
        public static void Seguir(SitePerfil1 umPost)
        {
            Erro.setErro(false);
            SitePerfilDAL.Seguir(umPost);
        }
        public static bool Estaseguindo(SitePerfil1 umPost)
        {
            Erro.setErro(false);
            return SitePerfilDAL.Estaseguindo(umPost);
        }
        public static void Deseguir(SitePerfil1 umPost)
        {
            Erro.setErro(false);
            SitePerfilDAL.Deseguir(umPost);
        }
        public static string Usuario(SitePerfil1 umPost)
        {
            Erro.setErro(false);
            return SitePerfilDAL.Usuario(umPost);
        }
    }
}
