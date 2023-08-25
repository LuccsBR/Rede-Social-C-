using ParaCasa1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desafio
{
    public partial class SitePerfilPO : UserControl
    {
        public static string[] save = new string[1000000];
        public static string[] saveI = new string[1000000];

        public int i = 999999;
        public static int i2 = 0;
        public static string NU;
        public static int N;


        public SitePerfilPO()
        {
            LimpaVariaveis();
            InitializeComponent();
            SitePerfilDAL.desconecta();
            SitePerfilDAL.conecta();
            SitePerfil1 c = new SitePerfil1();
            if (TelaDoSite.NomeUsuarioChamado != null)
                SitePerfilDAL.devolverPerfilO(c, TelaDoSite.NomeUsuarioChamado);
            else
                SitePerfilDAL.devolverPerfilO(c, TelaDoSiteS.NomeUsuarioChamado);
            Erro.setErro(false);
            TelaDoSiteTextos.limpaTudo();
            SitePerfilDAL.getProximo();
            while (!Erro.getErro())
            {

                save[i2] = TelaDoSiteTextos.getNomeUsuario();
                i2++;
                save[i2] = TelaDoSiteTextos.getTexto();
                i2++;
                saveI[i2 / 2] = TelaDoSiteTextos.getImagem();
                SitePerfilDAL.getProximo();
            }
            CriaPosts();

        }
        public void CriaPosts()
        {
            TelaDoSite b = new TelaDoSite();
            var result = b.CriarPost(save, 1, i2, saveI);
            for (int indice = 0; indice <= result.Item4[0]; indice++)
            {
                this.Controls.Add(result.Item1[indice]);
            }
            for (int indice = 0; indice < result.Item4[1]; indice++)
            {
                this.Controls.Add(result.Item2[indice]);
            }
            for (int indice = 0; indice <= result.Item4[2]; indice++)
            {
                this.Controls.Add(result.Item3[indice]);
            }
            for (int indice = 0; indice <= result.Item4[3]; indice++)
            {
                this.Controls.Add(result.Item5[indice]);
            }
            NU = result.Item2[1].Text;
            N = result.Item2.Length / 2;
        }
        public void LimpaVariaveis()
        {
            i = 999999;
            i2 = 0;
        }
    }
}