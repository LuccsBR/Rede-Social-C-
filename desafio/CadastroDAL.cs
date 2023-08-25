using ParaCasa1;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using L2.Services;

namespace desafio
{
    class CadastroDAL
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

        public static void inseriUmCadastro1(Cadastro1 umCadastro1)
        {
            Cadastro2 cadastro2 = new Cadastro2();
            Random random = new Random();
            string codigo = random.Next(100000, 999999).ToString();

            String aux = "insert into Cadastro(nm_nome,cd_email,dt_nascimento,cd_codigo) values (@nm_nome,@cd_email,@dt_nascimento,@cd_codigo)";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            try
            {
                strSQL.Parameters.Add("@nm_nome", OleDbType.VarChar).Value = umCadastro1.getNome();
                strSQL.Parameters.Add("@cd_email", OleDbType.VarChar).Value = umCadastro1.getEmail();
                strSQL.Parameters.Add("@dt_nascimento", OleDbType.VarChar).Value = umCadastro1.getNascimento();
                //strSQL.Parameters.Add("@cd_senha", OleDbType.VarChar).Value = umCadastro3.getSenha();
                ////strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = umCadastro4.getUsuario();
                strSQL.Parameters.Add("@cd_codigo", OleDbType.VarChar).Value = codigo;
                strSQL.ExecuteNonQuery();
                SmtpClient smtpClient = new SmtpClient("smtp.Office365.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("/*Email para envio de autenticação */", "/*Senha*/");

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("lo214377@alunos.unisanta.br");
                mailMessage.To.Add(new MailAddress(umCadastro1.getEmail()));
                mailMessage.Subject = "Código de Verificação";
                mailMessage.Body = "Seu código de verificação é: " + codigo;

                smtpClient.Send(mailMessage);

            }
            catch
            {
                Erro.setMsg("Email ja utilizado, se preferir, redefina a senha na página de Login!");
            }
        }


        public static void consultaUmCadastro(Cadastro1 umcadastro, Cadastro3 umCadastro3)
        {
            String aux = "select * from Cadastro where cd_email = @cd_email";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@cd_email", OleDbType.VarChar).Value = umcadastro.getEmail();

            result = strSQL.ExecuteReader();
            Erro.setErro(false);
            if (result.Read())
            {
                string email = result.GetString(0), senha = result.GetString(1);
                if (umcadastro.getEmail() != email || umCadastro3.getSenha() != senha)
                {
                    Erro.setMsg("Email e/ou senha estão incorretas!");
                }
            }
            else
            {
                Erro.setMsg("Email não cadastrado!");
            }


        }

        public static void verificaCodigo(Cadastro2 umcadastro)
        {

            String aux = "select * from Cadastro where cd_Email = @email";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@email", OleDbType.VarChar).Value =umcadastro.getEmail();

            result = strSQL.ExecuteReader();
            if (result.Read())
            {
                string codigo = result.GetString(5);

                Erro.setErro(false);
                if (umcadastro.getCodigo() != codigo)
                {
                    Erro.setMsg("Código Errado!");
                }
            }
        }
        public static void inseriSenha(Cadastro3 umcadastro)
        {
            String aux = "update Cadastro set cd_senha = @cd_senha where cd_Email= @cd_Email";
            strSQL = new OleDbCommand(aux, conn);
            Erro.setErro(false);
            strSQL.Parameters.Add("@cd_senha", OleDbType.VarChar).Value = umcadastro.getSenha();
            strSQL.Parameters.Add("@email", OleDbType.VarChar).Value = Frm_Cadastro1.Email;
            strSQL.ExecuteNonQuery();



        }
        public static void inseriUsuario(CadastroU umcadastro)
        {
            Erro.setErro(false);
            try
            {
                String aux = "update Cadastro set nm_usuario = @nm_usuario where cd_Email= @cd_Email";
                strSQL = new OleDbCommand(aux, conn);
                Erro.setErro(false);
                strSQL.Parameters.Add("@nm_usuario", OleDbType.VarChar).Value = umcadastro.getUsuario();
                strSQL.Parameters.Add("@email", OleDbType.VarChar).Value = Frm_Cadastro1.Email;
                strSQL.ExecuteNonQuery();
            }
            catch
            {
                Erro.setMsg("Este usuario já esta em uso, tente outro.");

            }
        }
        public static void Login(Login2 umcadastro)
        {
            Cryptography a = new Cryptography();
            String aux = "select * from Cadastro where cd_Email = @cd_Email";
            strSQL = new OleDbCommand(aux, conn);

            strSQL.Parameters.Add("@cd_Email", OleDbType.VarChar).Value = umcadastro.getEmail();

            result = strSQL.ExecuteReader();

            Erro.setErro(false);
            if (result.Read())
            {
                string email = result.GetString(1);
                string senha = result.GetString(3);
                if (umcadastro.getEmail().ToLower() != email.ToLower() || umcadastro.getSenha() != a.Decrypt(senha))
                {
                    Erro.setMsg("Email ou senha estão incorretas!");
                }
            }
            else
            {
                Erro.setMsg("Logado!");
            }
        }
            public static void EsqueciSenha(EsqueciSenha umcadastro)
            {
            Random random = new Random();
            string codigo = random.Next(100000, 999999).ToString();

            String aux = "select * from Cadastro where cd_Email = @cd_Email";
                strSQL = new OleDbCommand(aux, conn);

                strSQL.Parameters.Add("@cd_Email", OleDbType.VarChar).Value = umcadastro.getEmail();

                result = strSQL.ExecuteReader();

                Erro.setErro(false);
            if (result.Read())
            {
                string email = result.GetString(1);
                string senha = result.GetString(3);
                if (umcadastro.getEmail().ToLower() != email.ToLower())
                {
                    Erro.setMsg("Desculpe, mas não encontramos sua conta!");
                }
                else

                {
                    String aux2 = "update Cadastro set cd_codigo = @cd_codigo where cd_Email= @cd_Email";
                    strSQL = new OleDbCommand(aux2, conn);
                    Erro.setErro(false);
                    strSQL.Parameters.Add("@cd_codigo", OleDbType.VarChar).Value = codigo;
                    strSQL.Parameters.Add("@cd_Email", OleDbType.VarChar).Value = umcadastro.getEmail();
                    strSQL.ExecuteNonQuery();
                    SmtpClient smtpClient = new SmtpClient("smtp.Office365.com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = new NetworkCredential("lo214377@alunos.unisanta.br", "Santista72*");

                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("lo214377@alunos.unisanta.br");
                    mailMessage.To.Add(new MailAddress(umcadastro.getEmail()));
                    mailMessage.Subject = "Código de Verificação";
                    mailMessage.Body = "Seu código de verificação é: " + codigo;

                    smtpClient.Send(mailMessage);
                }
            }
                



            }
            public static void alteraSenha(EsqueciSenha3 umcadastro)
            {
                String aux = "update Cadastro set cd_senha = @cd_senha where cd_Email= @cd_Email";
                strSQL = new OleDbCommand(aux, conn);
                Erro.setErro(false);
                strSQL.Parameters.Add("@cd_senha", OleDbType.VarChar).Value = umcadastro.getSenha();
                strSQL.Parameters.Add("@email", OleDbType.VarChar).Value = umcadastro.getEmail();
                strSQL.ExecuteNonQuery();
            }


        }

}

