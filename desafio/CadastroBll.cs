using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ParaCasa1;
using Amazon.CodePipeline.Model;
using L2.Services;

namespace desafio
{

    class CadastroBll
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
        public static bool IsEmail(string strEmail)
        {
            string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void conecta()
        {
            CadastroDAL.conecta();
        }

        public static void desconecta()
        {
            CadastroDAL.desconecta();
        }

        public static void validaCodigo(Cadastro2 umCadastro)
        {
            Erro.setErro(false);
            if (umCadastro.getCodigo().Equals(""))
            {
                Erro.setMsg("O código é de preenchimento obrigatório!");
                return;
            }
            CadastroDAL.verificaCodigo(umCadastro);
        }

        public static void validaDados(Cadastro1 umCadastro)
        {
            Erro.setErro(false);
            if (umCadastro.getNome().Equals(""))
            {
                Erro.setMsg("O Nome é de preenchimento obrigatório!");
                return;
            }

            if (umCadastro.getEmail().Equals(""))
            {
                Erro.setMsg("O Email é de preenchimento obrigatório!");
                return;
            }
            if (IsEmail(umCadastro.getEmail()) == false)
            {
                Erro.setMsg("Digite um Email valido!");
                return;
            }
            int[] date = data();
            if (umCadastro.getNascimento().Day > 31)
            {
                Erro.setMsg("O campo Nascimento deve ser valido!");
                return;
            }
            else
            if (umCadastro.getNascimento().Month > 12)
            {
                Erro.setMsg("O campo Nascimento deve ser valido!");
                return;
            }
            if (umCadastro.getNascimento().Year > date[2])
            {
                Erro.setMsg("O campo Nascimento deve ser valido!");
                return;
            }
            CadastroDAL.inseriUmCadastro1(umCadastro);



        }
        public static void validaDados(Cadastro2 umCadastro)
        {
            Erro.setErro(false);
            if (umCadastro.getCodigo().Equals(""))
            {
                Erro.setMsg("O Codigo é de preenchimento obrigatório!");
                return;
            }
        }
        public static void validaDados(Cadastro3 umCadastro)
        {
            Erro.setErro(false);
            if (umCadastro.getSenha().Equals(""))
            {
                Erro.setMsg("O senha é de preenchimento obrigatório!");
                return;
            }
            if (umCadastro.getSenha().Length < 8)
            {
                Erro.setMsg("Sua senha precisa ter pelo menos 8 caracteres. Insira uma mais longa!");
                return;
            }
            Cryptography a = new Cryptography();
            umCadastro.setSenha(a.Encrypt(umCadastro.getSenha()));
            CadastroDAL.inseriSenha(umCadastro);

        }

        public static void validaDados(CadastroU umCadastro, int a)
        {
            if (umCadastro.getUsuario().Equals(""))
            {
                Erro.setMsg("O Usuario é de preenchimento obrigatório!");
                return;
            }
            if (a == 1)
            {
                CadastroDAL.inseriUsuario(umCadastro);
            }

        }
        public static void validaDados(Login2 umCadastro)
        {

            if (umCadastro.getEmail().Equals(""))
            {
                Erro.setMsg("O Email é de preenchimento obrigatório!");
                return;
            }
            if (IsEmail(umCadastro.getEmail()) == false)
            {
                Erro.setMsg("Digite um Email valido!");
                return;
            }
            if (umCadastro.getSenha().Equals(""))
            {
                Erro.setMsg("O senha é de preenchimento obrigatório!");
                return;
            }

            CadastroDAL.Login(umCadastro);
        }

        public static void validaDados(EsqueciSenha umCadastro)
        {

            if (umCadastro.getEmail().Equals(""))
            {
                Erro.setMsg("O Email é de preenchimento obrigatório!");
                return;
            }
            if (IsEmail(umCadastro.getEmail()) == false)
            {
                Erro.setMsg("Digite um Email valido!");
                return;
            }
            CadastroDAL.EsqueciSenha(umCadastro);
        }
        public static void validaDados(EsqueciSenha3 umCadastro)
        {
            Erro.setErro(false);
            if (umCadastro.getSenha().Equals(""))
            {
                Erro.setMsg("A senha é de preenchimento obrigatório!");
                return;
            }
            Cryptography a = new Cryptography();
            umCadastro.setSenha(a.Encrypt(umCadastro.getSenha()));
            CadastroDAL.alteraSenha(umCadastro);
        }
        public void Conecta()
        {
            CadastroDAL.conecta();
        }
       

    }
}

