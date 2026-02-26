using IncidentesAI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncidentesAI
{
    public partial class FormResumoImport : Form
    {
        public FormResumoImport()
        {
            InitializeComponent();
            CarregarDados();
            typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
                BindingFlags.Instance | BindingFlags.SetProperty, null, dgvResumo, new object[] { true });
        }

        public void CarregarDados()
        {
            try
            {
                string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;
                var dataService = new IncidenteDataService(caminhoDb);
                // todos os incidentes
                DataTable dt = dataService.ObterTodosIncidentes(numeroIncidentesConsiderar: 0);
                dgvResumo.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

    }
}
