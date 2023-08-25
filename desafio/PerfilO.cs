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
    public partial class PerfilO : Form
    {
        private Control userControlResume;
        public static Image ImgP;
        public static Image ImgB;
        public PerfilO()
        {
            InitializeComponent();
            ImagemDAL.desconecta();
            ImagemDAL.conecta();
            AdicionarImagem();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "UserControlResume";
            Navegacao a = new Navegacao();
            AdicionarAba(a.NovaGuia("tppp"));
            SitePerfil1 b = new SitePerfil1();
            if (SitePerfilBll.Usuario(b)== TelaDoSite.NomeUsuarioChamado)
            {
                button1.Visible = false;
                button1.Enabled = false;
            }
            label1.Text = TelaDoSite.NomeUsuarioChamado;
            label4.Text = TelaDoSite.NomeUsuarioChamado;
            b.setNomeUsuario(label4.Text);
            if (SitePerfilBll.Estaseguindo(b))
            {
                button1.Text = "Seguindo";

            }

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
            if (ImagemDAL.VerBannerO() != "")
            {
                pictureBox1.Image = System.Drawing.Image.FromFile(ImagemDAL.VerBannerO());

            }
            if (ImagemDAL.VerPerfilO() != "")
            {
                roundPictureBox1.Image = System.Drawing.Image.FromFile(ImagemDAL.VerPerfilO());

            }

        }
        private void label2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Seguir")
            {
                SitePerfil1 a = new SitePerfil1();
                a.setNomeUsuario(label4.Text);
                SitePerfilBll.Seguir(a);
                button1.Text = "Seguindo";
            }
            else
            {
                SitePerfil1 a = new SitePerfil1();
                a.setNomeUsuario(label4.Text);
                SitePerfilBll.Deseguir(a);
                button1.Text = "Seguir";

            }


        }
    }
}
