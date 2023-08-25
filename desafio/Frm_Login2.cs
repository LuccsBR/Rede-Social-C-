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
using System.Windows.Forms;

namespace desafio
{
    public partial class Frm_Login2 : Form
    {
        Login2 login2 = new Login2();
        public Frm_Login2()
        {
            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox2);
            sList.Add("Senha");
            SetCueBanner(ref tList, sList);
            Frm_Login a = new Frm_Login();
            textBox1.Text = a.EnviaEmail();
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr i, string str);

        void SetCueBanner(ref List<TextBox> textBox, List<string> CueText)
        {
            for (int x = 0; x < textBox.Count; x++)
            {
                SendMessage(textBox[x].Handle, 0x1501, (IntPtr)1, CueText[x]);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Frm_Cadastro1 a = new Frm_Cadastro1();
            a.ShowDialog();
            Close();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            Frm_Login b = new Frm_Login();
            login2.setEmail(textBox1.Text);
            
            login2.setSenha(textBox2.Text);

            CadastroBll.validaDados(login2);

            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                Erro.setErro(false);
                Close();
            }
            else
            {
                MeuSite a = new MeuSite();
                a.Logado(b.EnviaEmail());
                Close();
                
            }
        }
    }
}

