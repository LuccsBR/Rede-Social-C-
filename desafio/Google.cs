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
    public partial class Google : UserControl
    {
        public Google()
        {
            InitializeComponent();
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Navegacao a = new Navegacao();
            a.EnviarTexto(textBox1.Text, 3);
        }
        protected override void OnPaint(PaintEventArgs e)
        { 
             GraphicsPath forma = new GraphicsPath();
             forma.AddEllipse(0, 0, btnR.Width, btnR.Height);
             btnR.Region = new Region(forma);
    }

    public void CriarUC(string nome)
        {

        }

        
       

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Navegacao a = new Navegacao();
            TelaInicial b = new TelaInicial();
            b.tabControl1.TabPages.Add(a.NovaGuia("rs"));
        }
    }
}
