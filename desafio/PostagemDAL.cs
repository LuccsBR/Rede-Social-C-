using ParaCasa1;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    class PostagemDAL
    {
        private static String strConexao = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=SiteDesafio.mdb";
        private static OleDbConnection conn = new OleDbConnection(strConexao);
        private static OleDbCommand strSQL;
        private static OleDbDataReader result;
        private static OleDbDataReader result2;
        private static string[] Seguindo = new string[10000];
        private int indice = 9999;



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

        public static void inseriUmCadastro1(NovoPost umPost)
        {
            Cadastro2 cadastro2 = new Cadastro2();


            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);
            string sd = MeuSite.emailAtivo;
            strSQL.Parameters.Add("@cd_email", OleDbType.VarChar).Value = MeuSite.emailAtivo;

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                int id = result.GetInt32(6);
                String aux2 = "insert into Postagem(ID_Cadastro,Texto,Imagem) values (@ID_Cadastro,@Texto,@Imagem)";
                strSQL = new OleDbCommand(aux2, conn);
                Erro.setErro(false);
                PostagemBLL a = new PostagemBLL();
                NovoPost b = new NovoPost();
                try
                {
                    strSQL.Parameters.Add("@ID_Cadastro", OleDbType.VarChar).Value = id;
                    strSQL.Parameters.Add("@Texto", OleDbType.VarChar).Value = umPost.getTexto();
                    strSQL.Parameters.Add("@Imagem", OleDbType.VarChar).Value = umPost.getImage();
                    strSQL.ExecuteNonQuery();
                }
                catch
                {
                    Erro.setMsg("Este usuario já esta em uso, tente outro.");

                }
            }
        }
        public static void populaDRS()
        {
            String aux = "select * from Consulta1 where cd_email = @cd_email";

            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = MeuSite.emailAtivo;
            result = strSQL.ExecuteReader();
            if (result.Read())
            {
                String aux2 = "select * from Consulta1 where ";
                int indice = 0;
                try
                {
                    string NumerosSeguindo;
                    NumerosSeguindo = result.GetString(9);
                    string[] separado = NumerosSeguindo.Split(',');
                    NumerosSeguindo = "";
                    for (int i = 0; i < separado.Length; i++)
                    {
                        if (separado[i] != "")
                        {
                            if (aux2.Contains("ID"))
                            {
                                aux2 = aux2 + "OR ID = "+ separado[i]+" ";
                                Seguindo[indice] = separado[i];
                                indice++;

                            }
                            else
                            {
                                aux2 = aux2 + "ID = "+ separado[i]+" ";
                                Seguindo[indice] = separado[i];
                                indice++;

                            }
                        }
                        }
                }
                catch
                {
                }
                strSQL = new OleDbCommand(aux2, conn);
                result2 = strSQL.ExecuteReader();
            }
        }
        public static void populaDR()
        {
            String aux = "select * from Consulta1";

            strSQL = new OleDbCommand(aux, conn);
            result = strSQL.ExecuteReader();
        }
        public static void getProximo()
        {
            Erro.setErro(false);
            if (result.Read())
            {
                TelaDoSiteTextos.setNomeUsuario(result.GetString(4));
                TelaDoSiteTextos.setTexto(result.GetString(7));
                if(!result.IsDBNull(8)&& result.GetString(8)!="" )
                {
                    TelaDoSiteTextos.setImagem(result.GetString(8));
                }

            }
            else
                Erro.setErro(true);
        }
        public static void getProximoS()
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
    }
}



