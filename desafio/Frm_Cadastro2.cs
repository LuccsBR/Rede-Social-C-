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
    public partial class Frm_Cadastro2 : Form

    {
        Cadastro2 umcadastro2 = new Cadastro2();


        Frm_Cadastro1 a = new Frm_Cadastro1();
        public Frm_Cadastro2()
        {
            InitializeComponent();
            //List<TextBox> tList = new List<TextBox>();
            //List<string> sList = new List<string>();
            //tList.Add(textBox2);
            //sList.Add("Código de verificação");
            //SetCueBanner(ref tList, sList);
            label3.Text = label3.Text +" "+ a.EnviaEmail() + ".";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            umcadastro2.setCodigo(textBox2.Text);
            umcadastro2.setEmail(a.EnviaEmail());
            CadastroBll.validaDados(umcadastro2);
            CadastroBll.validaCodigo(umcadastro2);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                Frm_Cadastro3 a = new Frm_Cadastro3();
                a.ShowDialog();
                Close();
            }

            
        }
    }
}
