using ParaCasa1;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
     class ImagemDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SiteDesafio.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;

        public static void conecta()
        {
            try
            {
                conn.Open();
            }
            catch (Exception)
            {
                Erro.setMsg("Problemas ao se conectar ao Banco de Dados");
            }

        }

        public static void desconecta()
        {
            conn.Close();
        }
        public static void inseriBanner(Imagem umcadastro)
        {
            String aux = "update Cadastro set im_banner = @im_banner where cd_Email= @cd_Email";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            strSQL.Parameters.Add("@im_banner", OleDbType.VarChar).Value = umcadastro.getImagemB();
            strSQL.Parameters.Add("@cd_Email", OleDbType.VarChar).Value = MeuSite.emailAtivo;
            strSQL.ExecuteNonQuery();
        }
        public static void inseriPerfil(Imagem umcadastro)
        {
            String aux = "update Cadastro set im_perfil = @im_perfil where cd_Email= @cd_Email";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            strSQL.Parameters.Add("@im_perfil", OleDbType.VarChar).Value = umcadastro.getImagemP();
            strSQL.Parameters.Add("@cd_Email", OleDbType.VarChar).Value = MeuSite.emailAtivo;
            strSQL.ExecuteNonQuery();
        }
        public static string VerBanner()
        {
            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            strSQL.Parameters.Add("@cd_Email", OleDbType.VarChar).Value = MeuSite.emailAtivo;
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            string imgBanner ="";
            if (result.Read())
            {
                try
                {
                    imgBanner = result.GetString(8);

                }
                catch
                {
                    imgBanner = "";
                }
            }
            return imgBanner;
        }

        public static string VerPerfil()
        {
            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            strSQL.Parameters.Add("@cd_Email", OleDbType.VarChar).Value = MeuSite.emailAtivo;
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            string imgBanner = "";
            if (result.Read())
            {
                try
                {
                    imgBanner = result.GetString(7);

                }
                catch
                {
                    imgBanner = "";
                }
            }
            return imgBanner;
        }
        public static string VerPerfilB(string nomeU)
        {
            String aux = "select * from Cadastro where nm_usuario = @nm_usuario";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = nomeU;
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            string imgBanner = "";
            if (result.Read())
            {
                try{
                    imgBanner = result.GetString(7);

                }
                catch
                {
                    imgBanner = "";
                }
            }
            return imgBanner;
        }
        public static string VerBannerO()
        {
            String aux = "select * from Cadastro where nm_usuario = @nm_usuario";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            if(TelaDoSite.NomeUsuarioChamado!= null)
            strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = TelaDoSite.NomeUsuarioChamado;
            else
            strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = TelaDoSiteS.NomeUsuarioChamado;
            string dfg = TelaDoSite.NomeUsuarioChamado;
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            string imgBanner = "";
            if (result.Read())
            {
                try
                {
                    imgBanner = result.GetString(8);
                }
                catch
                {
                    imgBanner = "";
                }
            }
            return imgBanner;
        }

        public static string VerPerfilO()
        {
            String aux = "select * from Cadastro where nm_usuario = @nm_usuario";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            if (TelaDoSite.NomeUsuarioChamado != null)
                strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = TelaDoSite.NomeUsuarioChamado;
            else
                strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = TelaDoSiteS.NomeUsuarioChamado;
            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            string imgBanner = "";
            if (result.Read())
                try
            {
                imgBanner = result.GetString(7);
            }
            catch
            {
                imgBanner = "";
            }
            return imgBanner;
        }
    }
}

