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
    public partial class Frm_Cadastro1 : Form
    {
        Cadastro1 umcadastro1 = new Cadastro1();
        public static string Email;
        public Frm_Cadastro1()
        {
            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox1);
            sList.Add("Nome");
            SetCueBanner(ref tList, sList);
            List<TextBox> tList2 = new List<TextBox>();
            List<string> sList2 = new List<string>();
            tList2.Add(textBox2);
            sList2.Add("E-mail");
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
            umcadastro1.setNome(textBox1.Text);
            umcadastro1.setEmail(textBox2.Text);
            umcadastro1.setNascimento(dateTimePicker1.Value);
            Email = textBox2.Text;

            CadastroBll.validaDados(umcadastro1);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                Frm_Cadastro2 a = new Frm_Cadastro2();
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
