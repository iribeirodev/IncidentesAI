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
    public partial class FormPrompt : Form
    {
        public FormPrompt()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.FormPrompt_FormClosing);
        }

        private void SetTemperature()
        {
            double current = trackBar1.Value / 10.0;

            lblValue.Text = current.ToString("N1");

            Properties.Settings.Default.TemperaturaIA = current;
            Properties.Settings.Default.Save();
        }

        private void FormPrompt_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 9;

            // Carrega o prompt
            txtPrompt.Text = Properties.Settings.Default.PromptIA;

            double tempSalva = Properties.Settings.Default.TemperaturaIA;

            if (tempSalva < 0.1 || tempSalva > 0.9)
                tempSalva = 0.2;

            trackBar1.Value = (int)(tempSalva * 10);
            lblValue.Text = tempSalva.ToString("N1");
        }

        private void FormPrompt_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Atualiza o valor na memória e salva no properties
            Properties.Settings.Default.PromptIA = txtPrompt.Text;
            Properties.Settings.Default.Save();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            SetTemperature();
        }
    }
}
