using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace desafio
{
    public partial class Cadastro2
    {
        private string codigo;
        private String email;


        public void setCodigo(String _codigo) { codigo = _codigo; }
        public void setEmail(String _email) { email = _email; }



        public string getCodigo() { return codigo; }
        public String getEmail() { return email; }

    }
}
