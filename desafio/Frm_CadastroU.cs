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
    public partial class Frm_CadastroU : Form
    {
        CadastroU cadastroU = new CadastroU();

        public Frm_CadastroU()
        {
            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox2);
            sList.Add("Nome de usuário");
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

      

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_Cadastro1 a = new Frm_Cadastro1();
            cadastroU.setUsuario(textBox2.Text);

            CadastroBll.validaDados(cadastroU, 1);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                MeuSite b = new MeuSite();
                b.Logado(a.EnviaEmail());
                Close();
            }

        }
    }
}
