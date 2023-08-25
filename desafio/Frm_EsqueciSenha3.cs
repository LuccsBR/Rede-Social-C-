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
    public partial class Frm_EsqueciSenha3 : Form
    {
        EsqueciSenha3 umcadastro3 = new EsqueciSenha3();

        public Frm_EsqueciSenha3()
        {

            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox2);
            sList.Add("Digite uma nova senha");
            SetCueBanner(ref tList, sList);
            List<TextBox> tList2 = new List<TextBox>();
            List<string> sList2 = new List<string>();
            tList2.Add(textBox1);
            sList2.Add("Confirme sua senha");
            SetCueBanner(ref tList2, sList2);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_EsqueciSenha1 a = new Frm_EsqueciSenha1();
            umcadastro3.setSenha(textBox2.Text);
            umcadastro3.setEmail(a.EnviaEmail());

            CadastroBll.validaDados(umcadastro3);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                MessageBox.Show("Senha alterada com sucesso");
                MeuSite b = new MeuSite();
                b.Logado(a.EnviaEmail());
                Close();
            }
        }
    

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 8)
            {
                textBox2.ForeColor = Color.Red;
                label4.Visible = true;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                label4.Visible = false;
            }
        
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox1.Text)
            {
                textBox2.ForeColor = Color.Red;
                label2.Visible = true;
                button1.Enabled = false;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                label2.Visible = false;
                if (textBox2.Text.Length > 8)
                {
                    button1.Enabled = true;

                }

            }
        }
    }
}
