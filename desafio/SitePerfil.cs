using ParaCasa1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desafio
{
    public partial class SitePerfil : UserControl
    {
        private Control userControlResume;
        public static Image ImgP;
        public static Image ImgB;
        public SitePerfil()
        {
            InitializeComponent();
            ImagemDAL.desconecta();
            ImagemDAL.conecta();
            AdicionarImagem();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "UserControlResume";
            this.Size = new System.Drawing.Size(1260, 625);
            Navegacao a = new Navegacao();
            AdicionarAba(a.NovaGuia("tpp"));
            label1.Text = SitePerfilP.NU;
            label4.Text = SitePerfilP.NU;






        }
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, button1.Width, button1.Height);
            button1.Region = new Region(forma);
        }
        public void AdicionarAba(TabPage b)
        {
            b.Controls.Add(userControlResume);
            b.Location = new System.Drawing.Point(4, 29);
            b.Name = "tabPage";
            b.Size = new System.Drawing.Size(1270, 635);
            b.AutoScroll = true;
            tabControl1.TabPages.Add(b);
        }
        public void AdicionarImagem()
        {
            if (ImagemDAL.VerBanner() != "")
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(ImagemDAL.VerBanner());

            }
            if (ImagemDAL.VerPerfil() != "")
            {
                roundPictureBox1.Image = System.Drawing.Image.FromFile(ImagemDAL.VerPerfil());

            }

        }


        private void button1_Click(object sender, EventArgs e)
        {

            Frm_Imagem a = new Frm_Imagem();
            ImgP = roundPictureBox1.Image;
            ImgB = pictureBox1.Image;
            a.ShowDialog();
        }
    }
}
