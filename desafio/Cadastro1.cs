using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
     class Cadastro1
    {
        private String nome;
        private String email;
        private DateTime nascimento;



        public void setNome(String _nome) { nome = _nome; }
        public void setEmail(String _email) { email = _email; }
        public void setNascimento(DateTime Nascimento) { nascimento = Nascimento; }


        public String getNome() { return nome; }
        public String getEmail() { return email; }
        public DateTime getNascimento() { return nascimento; }


    }
}
