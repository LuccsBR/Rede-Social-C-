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
    public partial class TelaDoSiteS : UserControl
    {
        public static int labelU = 8;
        public static int labelB = 3;
        public static int labelT = 40;
        public static string[] save = new string[1000000];
        public static string[] saveI = new string[1000000];
        public static byte[] imagem;
        public static int i = 999999;
        public static int i3 = 0;
        public static string NomeUsuarioChamado;

        public void AjeitaVariaveis()

        {
            labelB = 3;
            labelU = 0;
            labelT = 40;
            i = 999999 ;
            i3 = 0;
           
        }
        public void AjeitaArray()
        {
            for (int a = 0; a < save.Length; a++)
            {
                save[a] = null;
                saveI[a] = null;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = sender as System.Windows.Forms.Button;
            if (clickedButton != null)
            {
                NomeUsuarioChamado = clickedButton.Name;
            }
            PerfilO a = new PerfilO();
            a.Show();
        }
        public TelaDoSiteS()
        {
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Name = "UserControlResume";
            this.Size = new System.Drawing.Size(1260, 625);
            AjeitaVariaveis();
            AjeitaArray();
            PostagemBLL.populaDRS();
            PostagemBLL.getProximoS();
            while (!Erro.getErro())
            {
                save[i3] = TelaDoSiteTextos.getNomeUsuario();
                i3++;
                save[i3] = TelaDoSiteTextos.getTexto();
                i3++;
                saveI[i3 / 2] = TelaDoSiteTextos.getImagem();
                int fd = i3 / 2;
                int fdsf = i3;
                PostagemBLL.getProximoS();



            }
            var result = CriarPost(save, 1, i3, saveI);
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



        }
        public Tuple<System.Windows.Forms.Button[], System.Windows.Forms.Label[], System.Windows.Forms.Panel[], int[], PictureBox[]> CriarPost(string[] texto, int chamado, int i2, string[] imagem = null)
        {
            AjeitaVariaveis();
            System.Windows.Forms.Button[] _B1 = new System.Windows.Forms.Button[i2+10];
            System.Windows.Forms.Label[] _L1 = new System.Windows.Forms.Label[i2 + 10];
            System.Windows.Forms.Panel[] _P1 = new System.Windows.Forms.Panel[i2 + 10];
            System.Windows.Forms.PictureBox[] _I1 = new System.Windows.Forms.PictureBox[i2 + 10];
            int imagemT = 145;
            int _iB = 0;
            float _iL = 0;
            int _iP = 0;
            int _iI = 0;
            int[] arraydeInt = new int[4];
            ImagemDAL.desconecta();
            ImagemDAL.conecta();
            for (; i > 0; i--)
            {
                bool temImagem = false;
                if (texto[i] != null)
                {
                    int tamanhoT = (texto[i].Length / 110) + 1;
                    if ((imagem[(i / 2) + 1] != null && imagem[(i / 2) + 12] != ""))
                    {
                        int fdsdf = i / 2;
                        int fgdfg = i / 2 + 1;
                        string ae = imagem[(i / 2) + 1];
                        try
                        {
                            PictureBox img = new PictureBox();
                            img.Location = new System.Drawing.Point(18, (labelT + (30 * tamanhoT)));
                            img.Size = new System.Drawing.Size(178, 145);
                            img.SizeMode = PictureBoxSizeMode.Zoom;
                            System.Drawing.Image image = System.Drawing.Image.FromFile(imagem[(i / 2) + 1]);
                            img.Image = image;
                            Frm_Login2 a = new Frm_Login2();
                            _I1[_iI] = img;
                            _iI++;
                            temImagem = true;
                            string fgsdg = imagem[i / 2];
                        }
                        catch { }

                    }
                    GraphicsPath forma = new GraphicsPath();
                    System.Windows.Forms.Button ButtonNU = new System.Windows.Forms.Button();
                    ButtonNU.Location = new System.Drawing.Point(3, labelB);
                    ButtonNU.AutoSize = true;
                    ButtonNU.Name = texto[i - 1];
                    ButtonNU.Font = new System.Drawing.Font("Segoe UI ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    ButtonNU.Name = texto[i - 1];
                    ButtonNU.Size = new System.Drawing.Size(45, 30);
                    ButtonNU.Text = "";
                    if (ImagemDAL.VerPerfilB(texto[i - 1]) != null && ImagemDAL.VerPerfilB(texto[i - 1]) != "")
                    {
                        ButtonNU.BackgroundImage = System.Drawing.Image.FromFile(ImagemDAL.VerPerfilB(texto[i - 1]));
                    }
                    ButtonNU.BackgroundImageLayout = ImageLayout.Zoom;
                    ButtonNU.Click += new System.EventHandler(this.button1_Click);
                    ButtonNU.FlatAppearance.BorderSize = 0;
                    ButtonNU.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    ButtonNU.Margin = new System.Windows.Forms.Padding(0);
                    ButtonNU.UseVisualStyleBackColor = true;
                    forma.AddEllipse(0, 0, ButtonNU.Width, ButtonNU.Height);
                    ButtonNU.Region = new Region(forma);
                    _B1[_iB] = ButtonNU;
                    _iB++;
                    System.Windows.Forms.Label LabelT = new System.Windows.Forms.Label();
                    LabelT.Location = new System.Drawing.Point(18, labelT);
                    LabelT.Name = "LabelT";
                    LabelT.Font = new System.Drawing.Font("Segoe UI", 10.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    LabelT.Size = new System.Drawing.Size(683, 30 * tamanhoT);
                    LabelT.TabIndex = 2;
                    LabelT.Text = texto[i];
                    _L1[Convert.ToInt32(_iL)] = LabelT;
                    _iL=_iL +1;
                    System.Windows.Forms.Label LabelNU = new System.Windows.Forms.Label();
                    LabelNU.Location = new System.Drawing.Point(45, labelU);
                    LabelNU.AutoSize = true;
                    LabelNU.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    LabelNU.Name = "LabelNU";
                    LabelNU.Size = new System.Drawing.Size(70, 25);
                    LabelNU.TabIndex = 0;

                    i = i - 1;
                    LabelNU.Text = texto[i];
                    _L1[Convert.ToInt32(_iL)] = LabelNU;
                    _iL++;
                    Width = 400;
                    Height = 300;
                    System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();
                    if (temImagem == true)
                    {
                        panel.Location = new Point(10, (labelU + (30 * tamanhoT)) + 50 + imagemT);
                        panel.Size = new Size(683, 2);
                        panel.BackColor = Color.Black;
                        _P1[_iP] = panel;
                        _iP++;
                        labelU += 100 + (30 * tamanhoT + imagemT);
                        labelB += 100 + (30 * tamanhoT + imagemT);
                        labelT += 100 + (30 * tamanhoT + imagemT);
                    }
                    else
                    {
                        panel.Location = new Point(10, (labelU + (30 * tamanhoT)) + 50);
                        panel.Size = new Size(683, 2);
                        panel.BackColor = Color.Black;
                        _P1[_iP] = panel;
                        _iP++;
                        labelU += 100 + (30 * tamanhoT);
                        labelB += 100 + (30 * tamanhoT);
                        labelT += 100 + (30 * tamanhoT);
                    }





                }

            }
            arraydeInt[0] = _iB;
            arraydeInt[1] = Convert.ToInt32(_iL);
            arraydeInt[2] = _iP;
            arraydeInt[3] = _iI;
            System.Windows.Forms.Label[] agfd = _L1;

            return new Tuple<System.Windows.Forms.Button[], System.Windows.Forms.Label[], System.Windows.Forms.Panel[], int[], PictureBox[]>(_B1, _L1, _P1, arraydeInt, _I1);



        }
    }
}
