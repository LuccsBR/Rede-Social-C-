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
    public partial class Frm_EsqueciSenha2 : Form
    {
        Cadastro2 esqueciSenha2 = new Cadastro2();

        public Frm_EsqueciSenha2()
        {
            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox2);
            sList.Add("Digite o código");
            SetCueBanner(ref tList, sList);
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
            esqueciSenha2.setCodigo(textBox2.Text);
            esqueciSenha2.setCodigo(a.EnviaEmail());
            CadastroBll.validaDados(esqueciSenha2);
            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                Frm_EsqueciSenha3 b = new Frm_EsqueciSenha3();
                b.ShowDialog();
                Close();

            }
        }
    }
}
