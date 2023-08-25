using ParaCasa1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace desafio
{
    public partial class Frm_EsqueciSenha1 : Form
    {
        public static string Email;

        EsqueciSenha esqueciSenha = new EsqueciSenha();
        public Frm_EsqueciSenha1()
        {
            InitializeComponent();
           
        }
       

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            esqueciSenha.setEmail(textBox2.Text);
            Email = textBox2.Text;
            CadastroBll.validaDados(esqueciSenha);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                Frm_EsqueciSenha2 a = new Frm_EsqueciSenha2();
                a.ShowDialog();
                Close();
            }
        }
        public string EnviaEmail()
        {
            return Email;

        }
    }

      
}
