using Amazon.Redshift.Model.Internal.MarshallTransformations;
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
    public partial class Frm_NovoPost : Form
    {
        NovoPost umnovopost = new NovoPost();
        public static string imagemC;
        public Frm_NovoPost()
        {
            imagemC = "";
            InitializeComponent();
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox2);
            sList.Add("What's happening?");
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

        private void button2_Click(object sender, EventArgs e)
        {
            string ads = imagemC;
            umnovopost.setTexto(textBox2.Text);
            bool v = false;
            string caminhoSalvar= " ";
            if(pictureBox1.Image != null)
            {
                for (int im = 0; v != true; im++)
                {
                    try
                    {
                        caminhoSalvar = "fotos\\imagem" + im + ".jpg";
                        pictureBox1.Image.Save(caminhoSalvar);
                        v = true;
                    }
                    catch
                    {

                    }

                }

            }
            
            umnovopost.setImage(caminhoSalvar);
            PostagemBLL.validaDados(umnovopost);

            if (Erro.getErro())
                MessageBox.Show(Erro.getMsg());
            else
            {
                MeuSite a = new MeuSite();
                a.atualiza();
                Close();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                button2.Enabled = true;
                string imagePath = openFileDialog.FileName;
                Image image = Image.FromFile(imagePath);
                textBox2.Text = " ";

                // Exibir a imagem no PictureBox
                this.pictureBox1.Image = image;
            }
        }
    }
}
