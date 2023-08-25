using Amazon.EC2.Import;
using ParaCasa1;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    class SitePerfilDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SiteDesafio.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;
        private static OleDbDataReader result2;

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
        public static void devolverPerfil(SitePerfil1 umPerfil)
        {
            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@cd_email", OleDbType.VarChar).Value = MeuSite.emailAtivo;

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                int id = result.GetInt32(6);
                String aux2 = "select * from Consulta1 where ID = @ID ";
                strSQL = new OleDbCommand(aux2, conn);
                strSQL.Parameters.Add("@ID", OleDbType.VarChar).Value = id;
                result2 = strSQL.ExecuteReader();
            }

        }
        public static void getProximo()
        {
            Erro.setErro(false);
            if (result2.Read())
            {
                TelaDoSiteTextos.setNomeUsuario(result2.GetString(4));
                TelaDoSiteTextos.setTexto(result2.GetString(7));
                if (!result2.IsDBNull(8) && result2.GetString(8) != "")
                {
                    TelaDoSiteTextos.setImagem(result2.GetString(8));
                }
            }
            else
                Erro.setErro(true);
        }
        public static void devolverPerfilO(SitePerfil1 umPerfil, string nomeUsuario)
        {
            String aux = "select * from Cadastro where nm_usuario = @nm_usuario";
            strSQL = new OleDbCommand(aux, conn);
            string agfd = nomeUsuario;
            strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = nomeUsuario;

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                int id = result.GetInt32(6);
                String aux2 = "select * from Consulta1 where ID = @ID ";
                strSQL = new OleDbCommand(aux2, conn);
                strSQL.Parameters.Add("@ID", OleDbType.VarChar).Value = id;
                result2 = strSQL.ExecuteReader();
            }

        }
        public static void Seguir(SitePerfil1 umPerfil)
        {
            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@cd_email", OleDbType.VarChar).Value = MeuSite.emailAtivo;

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                int id = result.GetInt32(6);
                String aux2 = "select * from Cadastro where nm_usuario = @nm_usuario";
                strSQL = new OleDbCommand(aux2, conn);
                SitePerfil1 a = new SitePerfil1();
                strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = a.getNomeUsuario();

                result2 = strSQL.ExecuteReader();
                Erro.setErro(false);
                if (result2.Read())
                {
                    int id2 = result2.GetInt32(6);
                    string NumerosSeguindo;
                    try
                    {
                        NumerosSeguindo = result.GetString(9);
                        string[] separado = NumerosSeguindo.Split(',');
                        bool tem = false;
                        for (int i = 0; i < separado.Length; i++)
                        {
                            if (separado[i] == id2.ToString())
                            {
                                tem = true;
                            }
                        }
                        if (!tem)
                        {
                            NumerosSeguindo = NumerosSeguindo + "," + id2.ToString();
                        }
                    }
                    catch
                    {
                        NumerosSeguindo = id2.ToString();
                    }
                    String aux3 = "update Cadastro set nm_seguindo = @nm_seguindo where ID= @ID";
                    strSQL = new OleDbCommand(aux3, conn);
                    strSQL.Parameters.Add("@ID", OleDbType.VarChar).Value = NumerosSeguindo;
                    strSQL.Parameters.Add("@nm_seguindo", OleDbType.VarChar).Value = id;
                    strSQL.ExecuteNonQuery();

                }
            }


        }
        public static bool Estaseguindo(SitePerfil1 umPerfil)
        {
            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@cd_email", OleDbType.VarChar).Value = MeuSite.emailAtivo;

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                int id = result.GetInt32(6);
                String aux2 = "select * from Cadastro where nm_usuario = @nm_usuario";
                strSQL = new OleDbCommand(aux2, conn);
                SitePerfil1 a = new SitePerfil1();
                strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = a.getNomeUsuario();

                result2 = strSQL.ExecuteReader();
                string NumerosSeguindo;
                bool Seguindo = false;

                Erro.setErro(false);
                if (result2.Read())
                {
                    int id2 = result2.GetInt32(6);
                    try
                    {
                        NumerosSeguindo = result.GetString(9);
                        string[] separado = NumerosSeguindo.Split(',');
                        for (int i = 0; i < separado.Length; i++)
                        {
                            if (separado[i] == id2.ToString())
                            {
                                Seguindo = true;

                            }
                        }
                    }
                    catch
                    {
                        Seguindo = false;
                    }

                }
                return Seguindo;

            }
            return false;



        }
        public static void Deseguir(SitePerfil1 umPerfil)
        {
            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@cd_email", OleDbType.VarChar).Value = MeuSite.emailAtivo;

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                int id = result.GetInt32(6);
                String aux2 = "select * from Cadastro where nm_usuario = @nm_usuario";
                strSQL = new OleDbCommand(aux2, conn);
                SitePerfil1 a = new SitePerfil1();
                strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = a.getNomeUsuario();

                result2 = strSQL.ExecuteReader();
                Erro.setErro(false);
                if (result2.Read())
                {
                    int id2 = result2.GetInt32(6);
                    string NumerosSeguindo = "";
                    string[] separado;

                    try
                    {
                        NumerosSeguindo = result.GetString(9);
                        separado =NumerosSeguindo.Split(',');
                        for (int i = 0; i < separado.Length; i++)
                        {
                            if (separado[i] == id2.ToString())
                            {
                                separado[i] = "";
                            }
                        }
                        NumerosSeguindo = "";
                        for (int i = 0; i < separado.Length; i++)
                        {
                            if (separado[i] !="")
                            {
                                if(i+1 < separado.Length)
                                {
                                    NumerosSeguindo = NumerosSeguindo + separado[i] + ",";

                                }
                                else
                                {
                                    NumerosSeguindo = NumerosSeguindo + separado[i];

                                }

                            }
                        }
                    }
                    catch
                    {
                    }
                   
                    String aux3 = "update Cadastro set nm_seguindo = @nm_seguindo where ID= @ID";
                    strSQL = new OleDbCommand(aux3, conn);
                    strSQL.Parameters.Add("@ID", OleDbType.VarChar).Value = NumerosSeguindo;
                    strSQL.Parameters.Add("@nm_seguindo", OleDbType.VarChar).Value = id;
                    strSQL.ExecuteNonQuery();

                }
            }



        }
        public static string Usuario(SitePerfil1 umPerfil)
        {
            String aux = "select * from Cadastro where nm_usuario = @nm_usuario";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = TelaDoSiteS.NomeUsuarioChamado;

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                return result.GetString(4);
               
            }
            return null;

        }
    }
}


