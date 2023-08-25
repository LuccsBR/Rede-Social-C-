using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Speech.Recognition;
using System.Speech.Synthesis;
using System.Globalization;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;

namespace desafio
{
    public partial class UserControl1 : UserControl
    {
        public string teste;
        static CultureInfo ci = new CultureInfo("pt-BR");
        static SpeechRecognitionEngine reconhecedor;
        SpeechSynthesizer resposta = new SpeechSynthesizer();// sintetizador de voz

        public string[] listaPalavar = { "rede social", "twitter" };
        public UserControl1()
        {
            InitializeComponent();
        }
        public void Gramatica()
        {
            try
            {
                reconhecedor = new SpeechRecognitionEngine(ci);

            }
            catch
            {
                MessageBox.Show("Erro ao integrar lingua escolhida");
            }
            var gramatica = new Choices();
            gramatica.Add(listaPalavar);
            var gb = new GrammarBuilder();
            gb.Append(gramatica);
            try
            {
                var g = new Grammar(gb);
                try{
                    reconhecedor.RequestRecognizerUpdate();
                    reconhecedor.LoadGrammarAsync(g);
                    reconhecedor.SpeechRecognized += Sre_Reconhecimento;
                    reconhecedor.SetInputToDefaultAudioDevice();
                    resposta.SetOutputToDefaultAudioDevice();
                    reconhecedor.RecognizeAsync(RecognizeMode.Multiple); 


                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERRO ao criar reconhecedor: " + ex.Message);


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void Init()
        {
            resposta.Volume = 100; // controla volume de saida
            resposta.Rate = 3; // velocidade de fala

            Gramatica(); // inicialização da gramatica
        }
        void Sre_Reconhecimento(object sender, SpeechRecognizedEventArgs e)
        {
            string frase = e.Result.Text;
            if (frase.Equals("rede social"))
            {
                textBox2.Text = "twitter.com";
                textBox1.Text = "twitter.com";

                Navegacao a = new Navegacao();
                a.EnviarTexto(textBox2.Text, 2);
                a.EnviarTexto(textBox1.Text, 1);

            }

        }

        public void button3_Click(object sender, EventArgs e)
        {

        }

        public void UserControl1_Load(object sender, EventArgs e)
        {

        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {

        }
        public string PegarTexto()
        {

            if (textBox2.Text != "")
            {
                return textBox2.Text;
            }
            else
            {
                return textBox1.Text;
                
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Navegacao a = new Navegacao();
            a.EnviarTexto(textBox1.Text,1);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Navegacao a = new Navegacao();
            a.EnviarTexto(textBox2.Text,2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Init();
        }






        //public void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    CAG(sender, e);
        //}

        //public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    CAG(sender, e);            
        //}
        //public void CAG(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == 13)
        //    {
        //        TelaInicial b = new TelaInicial();
        //        Navegacao a = new Navegacao();
        //        b.AdicionarAba(a.NovaGuia("google"), "google");
        //    }
        //}


    }
}
