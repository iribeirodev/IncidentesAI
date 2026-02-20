using IncidentesAI.Helpers;
using IncidentesAI.Services;

namespace IncidentesAI;

public partial class FormConfig : Form
{
    // Configurações
    private static Properties.Settings Settings => Properties.Settings.Default;

    public FormConfig()
    {
        InitializeComponent();
        CarregarConfiguracoes();
    }

    private void CarregarConfiguracoes()
    {
        txtCaminhoBanco.Text = Settings.UltimoCaminhoBanco;
        txtCaminhoPlanilha.Text = Settings.UltimoCaminhoExcel;
        AtualizarStatus(Settings.DataUltimaImportacao);
    }

    private bool CamposValidos()
    {
        if (!string.IsNullOrWhiteSpace(txtCaminhoPlanilha.Text) && !string.IsNullOrWhiteSpace(txtCaminhoBanco.Text))
            return false;

        UIHelper.MostrarAviso("Selecione os caminhos antes de importar.");
        return true;
    }

    private void AtualizarCaminhoBanco(string path)
    {
        txtCaminhoBanco.Text = path;
        Settings.UltimoCaminhoBanco = path;
        Settings.Save();
    }

    private void AtualizarCaminhoExcel(string path)
    {
        txtCaminhoPlanilha.Text = path;
        Settings.UltimoCaminhoExcel = path;
        Settings.Save();
    }

    private void SalvarLogImportacao()
    {
        string data = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        Settings.DataUltimaImportacao = data;
        Settings.Save();
        AtualizarStatus(data);
    }

    private void AtualizarStatus(string data)
    {
        bool temData = !string.IsNullOrEmpty(data);
        lblStatusImportacao.Text = temData ? $"Última atualização: {data}" : "Status: Nenhuma importação.";
        lblStatusImportacao.ForeColor = temData ? Color.Orange : Color.Sienna;
    }

    private void btnCriarDatabase_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCaminhoPlanilha.Text))
        {
            UIHelper.MostrarAviso("Por favor, selecione primeiro onde deseja salvar o banco.");
            return;
        }

        UIHelper.Executar(() =>
        {
            new IncidenteConfigService(txtCaminhoBanco.Text).CriarBancoDeDados();
            UIHelper.MostrarSucesso("Arquivo de banco de dados criado com sucesso!");
        });
    }

    private void btnImportar_Click(object sender, EventArgs e)
    {
        if (CamposValidos()) return;

        btnImportar.Enabled = false;

        UIHelper.Executar(() =>
        {
            new IncidenteConfigService(txtCaminhoBanco.Text)
                .ImportarPlanilha(txtCaminhoPlanilha.Text, (atual, total) =>
                {
                    progressBar1.Maximum = total;
                    progressBar1.Value = atual;
                    Application.DoEvents();
                }, limparDados: true);
        });

        SalvarLogImportacao();
        UIHelper.MostrarSucesso("Dados atualizados com sucesso!");

        btnImportar.Enabled = true;
    }

    private void btnEscolherCaminho_Click(object sender, EventArgs e)
    {
        using var dialog = new FolderBrowserDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
            AtualizarCaminhoBanco(Path.Combine(dialog.SelectedPath, "incidentes.db"));
    }

    private void btnEscolherCaminhoPlanilha_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog { Filter = "Arquivos Excel|*.xlsx;*.xls;*.csv" };
        if (dialog.ShowDialog() == DialogResult.OK)
            AtualizarCaminhoExcel(dialog.FileName);
    }

    private void FormConfig_Load(object sender, EventArgs e)
    {
        timerFade.Start();
    }

    private void timerFade_Tick(object sender, EventArgs e)
    {
        if (this.Opacity < 1)
            this.Opacity += 0.05;
        else
            timerFade.Stop();
    }
}
