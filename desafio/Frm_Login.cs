using Amazon.OpsWorks.Model;
using Castle.Components.DictionaryAdapter.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections;
using TextBox = System.Windows.Forms.TextBox;
using ParaCasa1;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace desafio
{
    public partial class Frm_Login : Form
    {
        public static string Email;
        CadastroU umcadastro = new CadastroU();

        public Frm_Login()
        {
            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox1);
            sList.Add("E-mail");
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

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Frm_Cadastro1 a = new Frm_Cadastro1();
            a.ShowDialog();
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Email = textBox1.Text;
            umcadastro.setUsuario(textBox1.Text);
            CadastroBll.validaDados(umcadastro,2);
            if (Erro.getErro())
            {
                MessageBox.Show(Erro.getMsg());
                Erro.setErro(false);
            }

            else
            {
                Frm_Login2 a = new Frm_Login2();
                a.ShowDialog();
                Close();
            }
        }
        public string EnviaEmail() 
        {
            return Email;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_EsqueciSenha1 a = new Frm_EsqueciSenha1();
            a.ShowDialog();
            Close();
        }
    }
}
