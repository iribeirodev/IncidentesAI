using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncidentesAI
{
    public partial class FormGrafico : Form
    {
        public ScottPlot.WinForms.FormsPlot Grafico => formsPlot1;
        private bool arrastando = false;
        private Point pontoInicial = new Point(0, 0);

        public FormGrafico()
        {
            InitializeComponent();

            this.MouseDown += FormGrafico_MouseDown;
            this.MouseMove += FormGrafico_MouseMove;
            this.MouseUp += FormGrafico_MouseUp;
        }

        private void FormGrafico_MouseUp(object sender, MouseEventArgs e)
        {
            arrastando = false;
        }

        private void FormGrafico_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastando)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - pontoInicial.X, p.Y - pontoInicial.Y);
            }
        }

        private void FormGrafico_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastando = true;
                pontoInicial = new Point(e.X, e.Y);
            }
        }

        private void lblFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
