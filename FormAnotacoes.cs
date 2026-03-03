using System.Data;
using IncidentesAI.Helpers;
using IncidentesAI.Services;

namespace IncidentesAI
{
    public partial class FormAnotacoes : Form
    {
        private string _numeroIncidente;
        private readonly AnotacaoDataService _anotacaoService;

        #region Constructor
        public FormAnotacoes(string numeroIncidente)
        {
            InitializeComponent();

            _anotacaoService = new AnotacaoDataService(Properties.Settings.Default.UltimoCaminhoBanco);

            CarregarSugestoesDeStatus();

            _numeroIncidente = numeroIncidente;
        }
        #endregion

        #region Eventos de UI
        private void FormAnotacoes_Load(object sender, EventArgs e)
        {
            txtNumero.Text = _numeroIncidente;

            DataTable dt = _anotacaoService.ObterDadosAnotacao(_numeroIncidente);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                cboStatus.Text = row["StatusInterno"].ToString();
                txtObservacao.Text = row["Observacao"].ToString();
                lblDataAtualizacao.Text = row["DataAtualizacao"].ToString();

                btnRemover.Enabled = true;
            }
            else
            {
                btnRemover.Enabled = false;
                btnRemover.BackColor = Color.White;
            }
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboStatus.Text))
            {
                UIHelper.MostrarAviso("O campo 'Status Interno' é obrigatório.");
                return;
            }

            if (string.IsNullOrEmpty(txtObservacao.Text))
            {
                UIHelper.MostrarAviso("O campo 'Observação' é obrigatório.");
                return;
            }

            _anotacaoService.SalvarAnotacao(txtNumero.Text, cboStatus.Text, txtObservacao.Text);

            UIHelper.MostrarSucesso("Anotações aplicadas ao incidente.");

            this.Close();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                $"Deseja realmente remover as anotações do incidente {txtNumero.Text}?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                _anotacaoService.RemoverAnotacao(txtNumero.Text);

                UIHelper.MostrarSucesso("Anotações removidas com sucesso!");

                this.Close();
            }
        }
        #endregion

        #region Métodos Private
        private void CarregarSugestoesDeStatus()
        {
            var status = _anotacaoService.ObterStatusExistentes();

            cboStatus.Items.Clear();
            foreach (var item in status)
                cboStatus.Items.Add(item);
        }
        #endregion
    }
}
