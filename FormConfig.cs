using IncidentesAI.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncidentesAI;

public partial class FormConfig : Form
{
    private IncidenteConfigService _service = new IncidenteConfigService("Data Source=incidentes.db");
    private string _caminhoDbFinal;
    private string _caminhoExcelSelecionado;

    public FormConfig()
    {
        InitializeComponent();
        CarregarConfiguracoes();
    }

    private void CarregarConfiguracoes()
    {
        // Ao abrir, preenche os campos com o que foi salvo na última execução
        txtCaminhoBanco.Text = Properties.Settings.Default.UltimoCaminhoBanco;
        txtCaminhoPlanilha.Text = Properties.Settings.Default.UltimoCaminhoExcel;

        string ultimaData = Properties.Settings.Default.DataUltimaImportacao;

        if (string.IsNullOrEmpty(ultimaData))
        {
            lblStatusImportacao.Text = "Status: Nenhuma importação realizada.";
            lblStatusImportacao.ForeColor = Color.Red;
        }
        else
        {
            lblStatusImportacao.Text = $"Última atualização: {ultimaData}";
            lblStatusImportacao.ForeColor = Color.Green;
        }
    }

    private void btnCriarDatabase_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(_caminhoDbFinal))
        {
            MessageBox.Show("Por favor, selecione primeiro onde deseja salvar o banco.");
            return;
        }

        try
        {
            // Atualizamos o service com o novo caminho (string de conexão)
            string connectionString = $"Data Source={_caminhoDbFinal};";
            var service = new IncidenteConfigService(connectionString);
            service.CriarBancoDeDados();

            MessageBox.Show("Arquivo de banco de dados criado com sucesso!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro: " + ex.Message);
        }
    }

    private void btnImportar_Click(object sender, EventArgs e)
    {
        string caminhoExcel = txtCaminhoPlanilha.Text;
        string caminhoDb = txtCaminhoBanco.Text;

        if (string.IsNullOrWhiteSpace(caminhoExcel) || string.IsNullOrWhiteSpace(caminhoDb))
        {
            MessageBox.Show("Selecione os caminhos antes de importar.");
            return;
        }

        btnImportar.Enabled = false;
        progressBar1.Value = 0;

        try
        {
            string connString = $"Data Source={caminhoDb};";
            var service = new IncidenteConfigService(connString);

            service.ImportarPlanilha(caminhoExcel, (atual, total) =>
            {
                progressBar1.Maximum = total;
                progressBar1.Value = atual;
                Application.DoEvents();
            }, limparDados: true);

            DateTime agora = DateTime.Now;
            string dataFormatada = agora.ToString("dd/MM/yyyy HH:mm:ss");
            // Salva na configuração do sistema
            Properties.Settings.Default.DataUltimaImportacao = dataFormatada;
            Properties.Settings.Default.Save();

            // Atualiza um Label na tela para o usuário ver
            lblStatusImportacao.Text = "Última importação: " + dataFormatada;

            MessageBox.Show("Dados atualizados com sucesso!");
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro na Importação: " + ex.Message);
        }
        finally
        {
            btnImportar.Enabled = true;
        }
    }

    private void btnEscolherCaminho_Click(object sender, EventArgs e)
    {
        using (var folderDialog = new FolderBrowserDialog())
        {
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                _caminhoDbFinal = Path.Combine(folderDialog.SelectedPath, "incidentes.db");
                txtCaminhoBanco.Text = _caminhoDbFinal;

                // Salva permanentemente
                Properties.Settings.Default.UltimoCaminhoBanco = _caminhoDbFinal;
                Properties.Settings.Default.Save();
            }
        }
    }

    private void btnEscolherCaminhoPlanilha_Click(object sender, EventArgs e)
    {
        using (var openDialog = new OpenFileDialog())
        {
            openDialog.Filter = "Arquivos Excel|*.xlsx;*.xls;*.csv";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _caminhoExcelSelecionado = openDialog.FileName;
                txtCaminhoPlanilha.Text = _caminhoExcelSelecionado;

                // Salva permanentemente
                Properties.Settings.Default.UltimoCaminhoExcel = _caminhoExcelSelecionado;
                Properties.Settings.Default.Save();
            }
        }
    }
}
