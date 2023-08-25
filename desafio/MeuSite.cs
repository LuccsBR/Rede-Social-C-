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
    public partial class MeuSite : UserControl
    {
        public static int logado =0;

        public static string emailAtivo;
        private Control userControlResume;

        public MeuSite()
        {
            InitializeComponent();
            PostagemDAL.desconecta();
            PostagemDAL.conecta();
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
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath forma = new GraphicsPath();
            forma.AddEllipse(0, 0, btnR.Width, btnR.Height);
            btnR.Region = new Region(forma);
        }
        Navegacao a = new Navegacao();
        private void button3_Click(object sender, EventArgs e)
        {
            if (logado == 0)
            {
                Frm_Login f = new Frm_Login();
                f.ShowDialog();
                if (logado == 1)
                {
                    button5.Enabled = true;
                    button4.Enabled = true;
                    button2.Enabled = true;
                    AdicionarAba(a.NovaGuia("tts"));


                }

            }
            else if (logado == 1)
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                AdicionarAba(a.NovaGuia("tp")); 
            }


        }
        public void Logado(string email)
        {
           logado = 1;
           emailAtivo = email;



        }

        private void button5_Click(object sender, EventArgs e)
        {
            logado = 0;
            if (logado == 0)
            { 
                button5.Enabled = false;
                button4.Enabled = false;
                button2.Enabled = false;
                Navegacao a = new Navegacao();
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                emailAtivo = "";
                TelaDoSite b = new TelaDoSite();
                b.AjeitaVariaveis();




            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_NovoPost a = new Frm_NovoPost();
            a.ShowDialog();

        }
        public void atualiza()
        {
            Navegacao a = new Navegacao();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            TelaDoSite b = new TelaDoSite();
            b.AjeitaVariaveis();
            Navegacao a = new Navegacao();
            TelaDoSiteTextos.limpaTudo();
            AdicionarAba(a.NovaGuia("tts"));
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            b.AjeitaVariaveis();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TelaDoSite b = new TelaDoSite();
            b.AjeitaVariaveis();
            Navegacao a = new Navegacao();
            TelaDoSiteTextos.limpaTudo();
            AdicionarAba(a.NovaGuia("tts"));
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
            TelaDoSite b = new TelaDoSite();
            b.AjeitaVariaveis();
            Navegacao a = new Navegacao();
            TelaDoSiteTextos.limpaTudo();
            AdicionarAba(a.NovaGuia("tt"));
            b.AjeitaVariaveis();
        }
    }
}
