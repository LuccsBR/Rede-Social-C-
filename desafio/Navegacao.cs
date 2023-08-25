using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace desafio
{
    class Navegacao
    {
        public static string[] GoogleURL = new string[6];
        public static string[] RSURL = new string[6];
        public static string urlE;
        public static string urlV;
        public static string urlP;
        public TabPage NovaGuia(string tipo)
        {
            if (tipo == "ng")
            {
                UserControl1 U = new UserControl1();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Google";
                TB.Text = "Google ";
                TB.Controls.Add(U);

                return TB;
            }
            else if (tipo == "google")
            {
                Google U = new Google();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Pesquisa sobre" + " ";
                TB.Text = "Pesquisa sobre" + " ";
                TB.Controls.Add(U);
                return TB;
            }
            else if (tipo == "rs")
            {
                MeuSite U = new MeuSite();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Meu Site";
                TB.Text = "Meu Site";
                TB.Controls.Add(U);
                return TB;
            }
            else if (tipo == "tt")
            {
                TelaDoSite U = new TelaDoSite();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Meu Site";
                TB.Text = "Meu Site";
                TB.Controls.Add(U);
                return TB;
            }
            else if (tipo == "tp")
            {
                SitePerfil U = new SitePerfil();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Meu Site";
                TB.Text = "Meu Site";
                TB.Controls.Add(U);
                return TB;
            }
            else if (tipo == "tpp")
            {
                SitePerfilP U = new SitePerfilP();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "       Tweets       ";
                TB.Text = "       Tweets       ";
                TB.Controls.Add(U);
                return TB;
            }
            else if (tipo == "tppp")
            {
                SitePerfilPO U = new SitePerfilPO();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "       Tweets       ";
                TB.Text = "       Tweets       ";
                TB.Controls.Add(U);
                return TB;
            }
            else if (tipo == "tts")
            {
                TelaDoSiteS U = new TelaDoSiteS();
                U.Dock = DockStyle.Fill;
                TabPage TB = new TabPage();
                TB.Name = "Meu Site";
                TB.Text = "Meu Site";
                TB.Controls.Add(U);
                return TB;
            }

                return null;
            
        }
        public string ValidaURL()
        {
            GoogleURL[0] = "www.google.com.br";
            GoogleURL[1] = "www.google.com";
            GoogleURL[2] = "google.com";
            GoogleURL[3] = "google.com.br";
            GoogleURL[4] = "https://www.google.com";
            GoogleURL[5] = "https://www.google.com.br";
            RSURL[0] = "www.twitter.com.br";
            RSURL[1] = "www.twitter.com";
            RSURL[2] = "twitter.com";
            RSURL[3] = "twitter.com.br";
            RSURL[4] = "https://www.twitter.com";
            RSURL[5] = "https://www.twitter.com.br";
            if (urlE != "")
            {
                for (int i = 0; i < GoogleURL.Length; i++)
                {
                    if (GoogleURL[i] == urlE)
                    {
                        urlE = "";
                        urlV = "";
                        urlP = "";
                        return "ng";


                    }
                    else if (RSURL[i] == urlE)
                    {
                        urlE = "";
                        urlV = "";
                        urlP = "";
                        return "rs";
                    }
                }
            }

            else if (urlV != "")
            {
                for (int i = 0; i < GoogleURL.Length; i++)
                {
                    if (GoogleURL[i] == urlV)
                    {
                        urlE = "";
                        urlV = "";
                        urlP = "";
                        return "ng";

                    }
                    else if (RSURL[i] == urlV)
                    {
                        urlE = "";
                        urlV = "";
                        urlP = "";
                        return "rs";
                    }
                }
            }else if(urlP != "") 
            {
                for (int i = 0; i < GoogleURL.Length; i++)
                {
                    if (GoogleURL[i] == urlP)
                    {
                        urlE = "";
                        urlV = "";
                        urlP = "";
                        return "ng";

                    }
                    else if (RSURL[i] == urlP)
                    {
                        urlE = "";
                        urlV = "";
                        urlP = "";
                        return "rs";
                    }
                }
            }
            if(urlV != "")
            {
                urlE = "";
                urlV = "";
                urlP = "";
                return "google";
            }
            else
            {
                urlE = "";
                urlV = "";
                urlP = "";
                return "google";

            }

        }
        public void EnviarTexto(string URL, int i)
        {
            if(i == 1)
            {
                urlE = URL;
                string afd = urlE;

            }
            else if (i == 2)
            {
                urlV = URL;
            }
            else if (i == 3)
            {
                urlP = URL;
            }
        }



    }
}
