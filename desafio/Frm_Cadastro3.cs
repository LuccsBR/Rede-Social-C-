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
    public partial class Frm_Cadastro3 : Form
    {
        Cadastro3 umcadastro3 = new Cadastro3();

        public Frm_Cadastro3()
        {
            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox2);
            sList.Add("Senha");
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length < 8)
            {
                textBox2.ForeColor = Color.Red;
                label4.Visible= true;
            }
            else
            {
                textBox2.ForeColor = Color.Black;
                label4.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            umcadastro3.setSenha(textBox2.Text);

            CadastroBll.validaDados(umcadastro3);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                Frm_CadastroU a = new Frm_CadastroU();
                a.ShowDialog();
                Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
