using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desafio
{
    public partial class TelaInicial : Form
    {
        public static string[] teste = new string[1000];
        public static int indiceA = -1;
        public static int indiceB = -1;
        public static int indiceHistorico = 1;
        public static string[] historico = new string[6];


        public TelaInicial()
        {
            InitializeComponent();
            CadastroBll a = new CadastroBll();
            a.Conecta();

        }

        private void novaGuiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Navegacao a = new Navegacao();
            AdicionarAba(a.NovaGuia("ng"));
            indiceA++;
            teste[indiceA] = "ng";
            salvarHistorico("ng");
            MeuSite.logado = 0;
            if (MeuSite.logado == 0)
            {
                MeuSite b = new MeuSite();
                b.button5.Enabled = false;
                b.button4.Enabled = false;
                b.button2.Enabled = false;
                MeuSite.emailAtivo = "";
                TelaDoSite d = new TelaDoSite();
                d.AjeitaVariaveis();




            }


        }

        private void fecharAbaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!(tabControl1.SelectedTab == null))
            {
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                if (MeuSite.logado == 0)
                {
                    MeuSite b = new MeuSite();
                    b.button5.Enabled = false;
                    b.button4.Enabled = false;
                    b.button2.Enabled = false;
                    MeuSite.emailAtivo = "";
                    TelaDoSite d = new TelaDoSite();
                    d.AjeitaVariaveis();

                }
            }
        }
        public void AdicionarAba(TabPage b)
        {
            tabControl1.TabPages.Add(b);
        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Navegacao a = new Navegacao();
            UserControl1 b = new UserControl1();
            Google c = new Google();
            MeuSite d = new MeuSite();
            string tipo = a.ValidaURL();
            indiceA++;
            teste[indiceA] = tipo;
            salvarHistorico(tipo);
            if (tipo == "ng")
            {
                AdicionarAba(a.NovaGuia("ng"));
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);





            }
            else if (tipo == "rs")
            {
                AdicionarAba(a.NovaGuia("rs"));
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                System.Windows.Forms.Label label5;
                label5 = new System.Windows.Forms.Label();
                label5.AutoSize = true;
                label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                label5.ForeColor = System.Drawing.Color.Blue;
                label5.Location = new System.Drawing.Point(16, 168);
                label5.Name = "label5";
                label5.Size = new System.Drawing.Size(172, 29);
                label5.TabIndex = 10;
                label5.Text = "Entrar no Site";


            }
            else
            {
                AdicionarAba(a.NovaGuia("google"));
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                c.CriarUC(a.ValidaURL());

            }






        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (indiceA > 0)
            {

                indiceB = indiceA;
                Navegacao a = new Navegacao();
                UserControl1 b = new UserControl1();
                indiceA = indiceA - 1;
                AdicionarAba(a.NovaGuia(teste[indiceA]));
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                if (indiceA < indiceB)
                {
                    toolStripMenuItem2.Enabled = true;
                }
            }

        }

        private void toolStripMenuItem2_MouseEnter(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (indiceA > 0)
            {
                Navegacao a = new Navegacao();
                UserControl1 b = new UserControl1();
                indiceA = indiceA + 1;
                AdicionarAba(a.NovaGuia(teste[indiceA]));
                tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                if (teste[indiceA = indiceA + 1] == null)
                {
                    toolStripMenuItem2.Enabled = false;

                }
            }
        }
        private void salvarHistorico(string tipo)
        {
            if (tipo == "ng")
            {
                for (int i = 1; i >= historico.Length; i++)
                {
                    if (historico[i] == null)
                    {
                        historico[i] = "ng";
                        if (i == 1)
                        {
                            toolStripMenuItem4.Text = "Google";
                        }
                        if (i == 2)
                        {
                            toolStripMenuItem5.Text = "Google";
                        }
                        if (i == 3)
                        {
                            toolStripMenuItem6.Text = "Google";
                        }
                        if (i == 4)
                        {
                            toolStripMenuItem7.Text = "Google";
                        }
                        if (i == 5)
                        {
                            toolStripMenuItem8.Text = "Google";
                        }
                    }
                    else
                    {
                        if (indiceHistorico >= 6)
                        {
                            indiceHistorico = 1;
                        }
                        historico[indiceHistorico] = "ng";
                        if (indiceHistorico == 1)
                        {
                            toolStripMenuItem4.Text = "Google";
                        }
                        if (indiceHistorico == 2)
                        {
                            toolStripMenuItem5.Text = "Google";
                        }
                        if (indiceHistorico == 3)
                        {
                            toolStripMenuItem6.Text = "Google";
                        }
                        if (indiceHistorico == 4)
                        {
                            toolStripMenuItem7.Text = "Google";
                        }
                        if (indiceHistorico == 5)
                        {
                            toolStripMenuItem8.Text = "Google";
                        }
                        indiceHistorico++;


                    }
                }
            }
            else if (tipo == "rs")
            {
                for (int i = 1; i >= historico.Length; i++)
                {
                    if (historico[i] == null)
                    {
                        historico[i] = "rs";
                        if (i == 1)
                        {
                            toolStripMenuItem4.Text = "Meu site";
                        }
                        if (i == 2)
                        {
                            toolStripMenuItem5.Text = "Meu site";
                        }
                        if (i == 3)
                        {
                            toolStripMenuItem6.Text = "Meu site";
                        }
                        if (i == 4)
                        {
                            toolStripMenuItem7.Text = "Meu site";
                        }
                        if (i == 5)
                        {
                            toolStripMenuItem8.Text = "Meu site";
                        }
                    }
                    else
                    {
                        if (indiceHistorico >= 6)
                        {
                            indiceHistorico = 1;
                        }
                        historico[indiceHistorico] = "rs";
                        if (indiceHistorico == 1)
                        {
                            toolStripMenuItem4.Text = "Meu site";
                        }
                        if (indiceHistorico == 2)
                        {
                            toolStripMenuItem5.Text = "Meu site";
                        }
                        if (indiceHistorico == 3)
                        {
                            toolStripMenuItem6.Text = "Meu site";
                        }
                        if (indiceHistorico == 4)
                        {
                            toolStripMenuItem7.Text = "Meu site";
                        }
                        if (indiceHistorico == 5)
                        {
                            toolStripMenuItem8.Text = "Meu site";
                        }
                        indiceHistorico++;


                    }
                }
            }

            else
            {
                for (int i = 1; i >= historico.Length; i++)
                {
                    if (historico[i] == null)
                    {
                        historico[i] = "Google";
                        if (i == 1)
                        {
                            toolStripMenuItem4.Text = "Pesquisa";
                        }
                        if (i == 2)
                        {
                            toolStripMenuItem5.Text = "Pesquisa";
                        }
                        if (i == 3)
                        {
                            toolStripMenuItem6.Text = "Pesquisa";
                        }
                        if (i == 4)
                        {
                            toolStripMenuItem7.Text = "Pesquisa";
                        }
                        if (i == 5)
                        {
                            toolStripMenuItem8.Text = "Pesquisa";
                        }
                    }
                    else
                    {
                        if (indiceHistorico >= 6)
                        {
                            indiceHistorico = 1;
                        }
                        historico[indiceHistorico] = "Google";
                        if (indiceHistorico == 1)
                        {
                            toolStripMenuItem4.Text = "Pesquisa";
                        }
                        if (indiceHistorico == 2)
                        {
                            toolStripMenuItem5.Text = "Pesquisa";
                        }
                        if (indiceHistorico == 3)
                        {
                            toolStripMenuItem6.Text = "Pesquisa";
                        }
                        if (indiceHistorico == 4)
                        {
                            toolStripMenuItem7.Text = "Pesquisa";
                        }
                        if (indiceHistorico == 5)
                        {
                            toolStripMenuItem8.Text = "Pesquisa";
                        }
                        indiceHistorico++;


                    }
                }
            }
        }
        }
    }

       //public void Google(TabPage b)
        //{
        //    AdicionarAba(b);
        //    int i = tabControl1.TabPages.Count;
        //    tabControl1.TabPages.RemoveAt(i-1);

        //}
    

