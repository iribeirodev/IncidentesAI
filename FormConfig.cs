using IncidentesAI.Components;
using IncidentesAI.Helpers;
using IncidentesAI.Services;
using System.Data;
using System.Windows.Forms;

namespace IncidentesAI;

public partial class FormConfig : Form
{
    // Configurações
    private static Properties.Settings Settings => Properties.Settings.Default;
    private List<long> idsParaExcluir = new List<long>();

    public FormConfig()
    {
        InitializeComponent();
        CarregarConfiguracoes();

        toolTip1.SetToolTip(lblExplicacao,
            "Tokens são unidades de texto que a IA processa.\n" +
            "Em média, 1 token equivale a 4 caracteres.\n" +
            "Quanto mais incidentes você incluir, mais tokens serão consumidos,\n" +
            "o que pode afetar o limite de uso da API."
        );

        try
        {
            CarregarIncidentesImportados();
        }
        catch
        {
        }

        dgvImported.DefaultCellStyle.ForeColor = Color.Black;

        DotNetEnv.Env.Load();

        lblModelo.Text = Environment.GetEnvironmentVariable("MISTRAL_MODEL");
        lblEndpoint.Text = Environment.GetEnvironmentVariable("MISTRAL_ENDPOINT");
    }

    private void CarregarConfiguracoes()
    {
        txtCaminhoBanco.Text = Settings.UltimoCaminhoBanco;
        txtCaminhoPlanilha.Text = Settings.UltimoCaminhoExcel;
        trackBarNumeroIncidentes.Value = Settings.NumeroIncidentes;
        lblNumeroIncidentes.Text = trackBarNumeroIncidentes.Value.ToString();
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
        if (string.IsNullOrWhiteSpace(txtCaminhoBanco.Text))
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
                    progressBar0.Maximum = total;

                    ((AnimatedProgressBar)progressBar0).SetValueAnimated(atual);

                    Application.DoEvents();
                }, limparDados: true);
        });

        progressBar0.Value = progressBar0.Maximum;

        SalvarLogImportacao();
        CarregarIncidentesImportados();
        //dgvImported.Invalidate();
        AtualizarBotoesGrid();
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

    private void trackBarNumeroIncidentes_Scroll(object sender, EventArgs e)
    {
        lblNumeroIncidentes.Text = trackBarNumeroIncidentes.Value.ToString();
        Settings.NumeroIncidentes = int.Parse(lblNumeroIncidentes.Text);
        Settings.Save();
    }

    private void CarregarIncidentesImportados()
    {
        string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;
        var dataService = new IncidenteDataService(caminhoDb);

        var incidentes = dataService.ObterTodosIncidentes(numeroIncidentesConsiderar: 0);
        dgvImported.DataSource = incidentes;
    }

    private void AtualizarBotoesGrid()
    {
        bool temItensMarcados = idsParaExcluir.Count > 0;

        btnDesmarcarTodas.Enabled = temItensMarcados;
        btnRemoverSelecionadas.Enabled = temItensMarcados;
    }

    private void DesmarcarLinhasGrid()
    {
        idsParaExcluir.Clear();

        dgvImported.Invalidate();

        AtualizarBotoesGrid();

        dgvImported.Focus();
    }

    private void dgvImported_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete && dgvImported.CurrentRow != null)
        {
            long id = Convert.ToInt64(dgvImported.CurrentRow.Cells["ID"].Value);

            if (idsParaExcluir.Contains(id))
                idsParaExcluir.Remove(id);
            else
                idsParaExcluir.Add(id);

            dgvImported.ClearSelection();
            dgvImported.CurrentRow.Selected = false;
            dgvImported.InvalidateRow(dgvImported.CurrentRow.Index);

            AtualizarBotoesGrid();
            e.Handled = true;
        }
    }

    private void dgvImported_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
    {
        // Ignora o cabeçalho
        if (e.RowIndex < 0) return;

        var cellValue = dgvImported.Rows[e.RowIndex].Cells["ID"].Value;

        if (cellValue != null && cellValue != DBNull.Value && idsParaExcluir.Contains(Convert.ToInt64(cellValue)))
        {
            dgvImported.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
            dgvImported.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.White;

            dgvImported.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Red;
            dgvImported.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.White;
        }
        else
        {
            dgvImported.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            dgvImported.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;

            dgvImported.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            dgvImported.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = SystemColors.HighlightText;
        }
    }

    private void btnDesmarcarTodas_Click(object sender, EventArgs e)
    {
        DesmarcarLinhasGrid();
    }

    private void btnRemoverSelecionadas_Click(object sender, EventArgs e)
    {
        int total = idsParaExcluir.Count;

        // 1. Pergunta ao usuário se ele tem certeza
        DialogResult confirmacao = MessageBox.Show(
            $"Tem certeza que deseja remover {total} registro(s) marcado(s)?",
            "Confirmar Exclusão",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (confirmacao == DialogResult.Yes)
        {
            try
            {
                string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;
                var dataService = new IncidenteDataService(caminhoDb);

                idsParaExcluir.ForEach(id =>
                {
                    dataService.ExcluirIncidentePorId((int)id);
                });

                idsParaExcluir.Clear();
                DesmarcarLinhasGrid();
                CarregarIncidentesImportados();
                AtualizarBotoesGrid();

                MessageBox.Show("Registro(s) removido(s) com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void dgvImported_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        // O número a ser exibido (índice da linha + 1)
        string conteudoRowHeader = (e.RowIndex + 1).ToString();

        // Formata o texto (centralizado)
        var formatoTexto = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        // Define a área onde o número será desenhado (o cabeçalho da linha)
        var areaHeader = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                                       dgvImported.RowHeadersWidth, e.RowBounds.Height);

        // Desenha o número usando a fonte padrão do Grid
        e.Graphics.DrawString(conteudoRowHeader,
                              dgvImported.Font,
                              SystemBrushes.ControlText,
                              areaHeader,
                              formatoTexto);
    }
}
