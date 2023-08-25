using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desafio
{
    public partial class Frm_Imagem : Form
    {
        public Frm_Imagem()
        {
            InitializeComponent();
            ImagemDAL.desconecta();
            ImagemDAL.conecta();
            adicionaImagem();
            textBox1.Text= SitePerfilP.NU;
            List<TextBox> tList = new List<TextBox>();
            List<string> sList = new List<string>();
            tList.Add(textBox1);
            sList.Add("Name");
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
        public void adicionaImagem()
        {
            if (ImagemDAL.VerBanner() != "")
            {
                pictureBox2.Image = System.Drawing.Image.FromFile(ImagemDAL.VerBanner());

            }
            if (ImagemDAL.VerPerfil() != "")
            {
                roundPictureBox1.Image = System.Drawing.Image.FromFile(ImagemDAL.VerPerfil());

            }
        }
    protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, button1.Width, button1.Height);
            button1.Region = new Region(forma);
        }
        private void label1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                Image image = Image.FromFile(imagePath);
                // Exibir a imagem no PictureBox
                this.pictureBox2.Image = image;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Imagens (*.jpg; *.png; *.gif)|*.jpg;*.png;*.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;
                Image image = Image.FromFile(imagePath);
                // Exibir a imagem no PictureBox
                this.roundPictureBox1.Image = image;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.pictureBox2.Image = null;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string caminhoSalvar = " ";
            if (pictureBox2.Image != SitePerfil.ImgB)
            {
                bool v = false;

                for (int im = 0; v != true; im++)
                {
                    try
                    {
                        if(pictureBox2.Image== null)
                        {
                            caminhoSalvar = "";
                            v = true;

                        }
                        else
                        {
                            caminhoSalvar = "fotos\\imagem" + im + ".jpg";
                            pictureBox2.Image.Save(caminhoSalvar);
                            v = true;
                        }
                       
                    }
                    catch
                    {

                    }

                }

                Imagem a = new Imagem();
                Imagem.setImagemB(caminhoSalvar);
                ImagemBll.enviaFBanner(a);
            }
            if (roundPictureBox1!= null || roundPictureBox1.Image != SitePerfil.ImgP)
            {
                bool v = false;
               

                for (int im = 0; v != true; im++)
                {
                    try
                    {
                        caminhoSalvar = "fotos\\imagem" + im+1 + ".jpg";
                        roundPictureBox1.Image.Save(caminhoSalvar);
                        v = true;
                    }
                    catch
                    {

                    }

                }
                Imagem a = new Imagem();
                Imagem.setImagemP(caminhoSalvar);
                ImagemBll.enviaFPerfil(a);
            }
            Close();
            SitePerfil b = new SitePerfil();
            b.AdicionarImagem();
        }
    }
}

