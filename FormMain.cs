using System.ComponentModel;
using System.Data;
using System.Text;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using IncidentesAI.Plugins;
using IncidentesAI.Services;
using Microsoft.SemanticKernel;

namespace IncidentesAI
{
    public partial class FormMain : Form
    {
        private Kernel _kernel;
        private List<string> _historicoPerguntas = new List<string>();
        private int _indiceHistorico = -1;
        private readonly string _caminhoArquivoHistorico = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "historico.txt");

        public FormMain()
        {
            InitializeComponent();

            chkFiltrarData.Checked = false;
            dtpInicio.Enabled = false;
            dtpFim.Enabled = false;

            CarregarHistoricoDoArquivo();

            SetupKernel();
        }

        #region Métodos principais
        private void SetupKernel()
        {
            // Carrega as variáveis do arquivo .env para o ambiente
            DotNetEnv.Env.Load();

            string apiKey = Environment.GetEnvironmentVariable("MISTRAL_API_KEY");
            string modelId = Environment.GetEnvironmentVariable("MISTRAL_MODEL");
            string endpoint = Environment.GetEnvironmentVariable("MISTRAL_ENDPOINT");

            var builder = Kernel.CreateBuilder();
            builder.AddOpenAIChatCompletion(
                modelId: modelId,
                apiKey: apiKey,
                endpoint: new Uri(endpoint)
            );

            builder.Plugins.AddFromObject(new ExcelPlugin(this.dgvIncidentes));
            builder.Plugins.AddFromObject(this);
            _kernel = builder.Build();
        }

        private void CarregarHistoricoDoArquivo()
        {
            if (File.Exists(_caminhoArquivoHistorico))
            {
                _historicoPerguntas = File.ReadAllLines(_caminhoArquivoHistorico).ToList();
                _indiceHistorico = _historicoPerguntas.Count;
            }
        }

        private void SalvarPerguntaNoHistorico(string pergunta)
        {
            if (string.IsNullOrWhiteSpace(pergunta)) return;

            // Adiciona na lista e reseta o índice para o final
            _historicoPerguntas.Add(pergunta);
            _indiceHistorico = _historicoPerguntas.Count;

            // Salva no arquivo (Append)
            File.AppendAllLines(_caminhoArquivoHistorico, new[] { pergunta });
        }

        public void CarregarDados()
        {
            try
            {
                string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;
                var dataService = new IncidenteDataService(caminhoDb);
                DataTable dt = dataService.ObterTodosIncidentes();
                dgvIncidentes.DataSource = dt;
                ConfigurarLayoutGrid();

                PreencherCombosFiltro();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void ConfigurarLayoutGrid()
        {
            if (dgvIncidentes.Columns.Count > 0)
            {
                dgvIncidentes.ReadOnly = true;

                dgvIncidentes.AllowUserToAddRows = false;
                dgvIncidentes.AllowUserToDeleteRows = false;

                // ocultando o id
                if (dgvIncidentes.Columns.Contains("Id"))
                    dgvIncidentes.Columns["Id"].Visible = false;

                dgvIncidentes.Columns["Number"].HeaderText = "Chamado";
                dgvIncidentes.Columns["AssignmentGroup"].HeaderText = "Grupo de Atribuição";
                dgvIncidentes.Columns["State"].HeaderText = "Status";
                dgvIncidentes.Columns["Caller"].HeaderText = "Solicitante";
                dgvIncidentes.Columns["AssignedTo"].HeaderText = "Atribuído a";
                dgvIncidentes.Columns["Priority"].HeaderText = "Prioridade";
                dgvIncidentes.Columns["Created"].HeaderText = "Data de Criação";
                dgvIncidentes.Columns["ShortDescription"].HeaderText = "Descrição";
                dgvIncidentes.Columns["ConfigurationItem"].HeaderText = "Item de Configuração";
                dgvIncidentes.Columns["Email"].HeaderText = "E-mail";

                dgvIncidentes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvIncidentes.Columns["Number"].Frozen = true;

                dgvIncidentes.MultiSelect = false;
            }
        }

        private void PreencherCombosFiltro()
        {
            string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;

            if (string.IsNullOrEmpty(caminhoDb) || !System.IO.File.Exists(caminhoDb))
                return;

            try
            {
                var dataService = new IncidenteDataService(caminhoDb);

                var itensCI = dataService.ObterItensConfiguracaoUnicos();
                cboConfigurationItem.Items.Clear();
                cboConfigurationItem.Items.Add("--- Todos ---");
                cboConfigurationItem.Items.AddRange(itensCI.ToArray());
                cboConfigurationItem.SelectedIndex = 0;

                var itensStatus = dataService.ObterStatusUnicos();
                cboStatus.Items.Clear();
                cboStatus.Items.Add("--- Todos ---");
                cboStatus.Items.AddRange(itensStatus.ToArray());
                cboStatus.SelectedIndex = 0;

                var itensCaller = dataService.ObterCallersUnicos();
                cboCaller.Items.Clear();
                cboCaller.Items.Add("--- Todos ---");
                cboCaller.Items.AddRange(itensCaller.ToArray());
                cboCaller.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar filtros: " + ex.Message);
            }
        }

        private void FiltrarDados()
        {
            DataTable dt = (DataTable)dgvIncidentes.DataSource;
            if (dt == null) return;

            List<string> condicoes = new List<string>();

            string num = txtNumber.Text.Trim();
            string desc = txtShortDescription.Text.Trim();

            if (!string.IsNullOrEmpty(num))
                condicoes.Add(string.Format("Number LIKE '%{0}%'", num));

            if (!string.IsNullOrEmpty(desc))
                condicoes.Add(string.Format("ShortDescription LIKE '%{0}%'", desc));

            if (cboConfigurationItem.SelectedIndex > 0)
                condicoes.Add(string.Format("ConfigurationItem = '{0}'", cboConfigurationItem.Text.Replace("'", "''")));

            if (cboStatus.SelectedIndex > 0)
                condicoes.Add(string.Format("State = '{0}'", cboStatus.Text.Replace("'", "''")));

            if (cboCaller.SelectedIndex > 0)
                condicoes.Add(string.Format("Caller = '{0}'", cboCaller.Text.Replace("'", "''")));

            if (chkFiltrarData.Checked)
            {
                string dataInicio = dtpInicio.Value.ToString("MM/dd/yyyy");
                string dataFim = dtpFim.Value.ToString("MM/dd/yyyy");

                condicoes.Add(string.Format("Created >= #{0} 00:00:00# AND Created <= #{1} 23:59:59#", dataInicio, dataFim));
            }

            dt.DefaultView.RowFilter = condicoes.Count > 0 ? string.Join(" AND ", condicoes) : "";

            // Atualização da Label de Contagem
            if (condicoes.Count == 0)
            {
                lblCntFilter.Text = "";
            }
            else
            {
                int totalFiltrado = dt.DefaultView.Count;
                int totalGeral = dt.Rows.Count;

                if (totalFiltrado == 0)
                {
                    lblCntFilter.Text = "Nenhum registro encontrado.";
                    lblCntFilter.ForeColor = Color.Red;
                }
                else
                {
                    lblCntFilter.Text = $"Encontrado: {totalFiltrado} de {totalGeral}";
                    lblCntFilter.ForeColor = Color.Green;
                }
            }
        }

        private void AdicionarTextoFormatado(string autor, string texto, Color corTexto)
        {
            string dataHora = $"[{DateTime.Now:HH:mm}] ";
            txtHistorico.SelectionStart = txtHistorico.TextLength;
            txtHistorico.SelectionFont = new Font(txtHistorico.Font, FontStyle.Bold);
            txtHistorico.SelectionColor = Color.Gray;
            txtHistorico.AppendText($"\n\n{dataHora}");

            txtHistorico.SelectionColor = corTexto;
            txtHistorico.AppendText($"{autor}: ");

            string[] partes = texto.Split(new string[] { "**" }, StringSplitOptions.None);
            for (int i = 0; i < partes.Length; i++)
            {
                txtHistorico.SelectionStart = txtHistorico.TextLength;
                txtHistorico.SelectionFont = new Font(txtHistorico.Font, (i % 2 != 0) ? FontStyle.Bold : FontStyle.Regular);
                txtHistorico.SelectionColor = corTexto;
                txtHistorico.AppendText(partes[i]);
            }

            txtHistorico.ScrollToCaret();

        }
        #endregion

        #region Eventos de UI
        private void FormMain_Load(object sender, EventArgs e) => CarregarDados();

        private void btnFiltrar_Click(object sender, EventArgs e) => FiltrarDados();

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNumber.Text = "";
            txtShortDescription.Text = "";

            cboConfigurationItem.SelectedIndex = 0;
            cboStatus.SelectedIndex = 0;
            cboCaller.SelectedIndex = 0;

            chkFiltrarData.Checked = false;
            dtpInicio.Value = DateTime.Now.AddDays(-30);
            dtpFim.Value = DateTime.Now;

            FiltrarDados();
        }

        private void chkFiltrarData_CheckedChanged(object sender, EventArgs e)
        {
            // Habilita/Desabilita os calendários
            dtpInicio.Enabled = chkFiltrarData.Checked;
            dtpFim.Enabled = chkFiltrarData.Checked;

            if (chkFiltrarData.Checked)
            {
                chkFiltrarData.ForeColor = Color.Blue;
                chkFiltrarData.Text = "Filtrando por período:";
            }
            else
            {
                chkFiltrarData.ForeColor = Color.Black;
                chkFiltrarData.Text = "Filtrar por período de criação";
            }

            FiltrarDados();
        }

        private async void btnProcessar_Click(object sender, EventArgs e)
        {
            string userPrompt = txtPergunta.Text;

            if (string.IsNullOrWhiteSpace(userPrompt))
            {
                MessageBox.Show("Por favor, digite uma pergunta ou comando.");
                return;
            }

            SalvarPerguntaNoHistorico(userPrompt);

            AdicionarTextoFormatado("Usuário", userPrompt, Color.Black);
            btnProcessar.Enabled = false;
            lblStatus.Text = "Consultando Mistral AI...";
            Cursor = Cursors.WaitCursor;

            try
            {
                string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;
                var dataService = new IncidenteDataService(caminhoDb);
                string contextoDados = dataService.ObterContextoParaIA(100);

                string systemMessage = Properties.Settings.Default.PromptIA;

                StringBuilder fullPrompt = new StringBuilder();
                fullPrompt.AppendLine("### INSTRUÇÕES DE SISTEMA ###");
                fullPrompt.AppendLine(systemMessage);
                fullPrompt.AppendLine("\n### DADOS DOS TICKETS (CONTEXTO) ###");
                fullPrompt.AppendLine(contextoDados);
                fullPrompt.AppendLine("\n### PERGUNTA DO USUÁRIO ###");
                fullPrompt.AppendLine(userPrompt);

                double tempValue = 0.1;
                try
                {
                    string tempConfig = Properties.Settings.Default.TemperaturaIA.ToString().Replace(",", ".");
                    tempValue = double.Parse(tempConfig, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch { tempValue = 0.1; }

                var settings = new OpenAIPromptExecutionSettings
                {
                    ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                    Temperature = tempValue
                };

                var arguments = new KernelArguments(settings);

                try
                {
                    var resposta = await _kernel.InvokePromptAsync(fullPrompt.ToString(), arguments);

                    lblStatus.Text = "Pronto!";
                    AdicionarTextoFormatado("IA", resposta.ToString(), Color.DarkMagenta);
                    txtPergunta.Clear();
                }
                catch (HttpOperationException httpEx)
                {
                    MessageBox.Show($"Erro na API Mistral:\n{httpEx.ResponseContent}");
                    lblStatus.Text = "Erro na API.";
                }
            }
            catch (Exception ex)
            {
                string erroMensagem = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Erro: {erroMensagem}");
                lblStatus.Text = "Erro na operação.";
            }
            finally
            {
                btnProcessar.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnPrompt_Click(object sender, EventArgs e)
        {
            FormPrompt formPrompt = new FormPrompt();
            formPrompt.ShowDialog();
        }

        private void btnHistoricoUp_Click(object sender, EventArgs e)
        {
            if (_historicoPerguntas.Count > 0 && _indiceHistorico > 0)
            {
                _indiceHistorico--;
                txtPergunta.Text = _historicoPerguntas[_indiceHistorico];
            }
        }

        private void btnHistoricoDown_Click(object sender, EventArgs e)
        {
            if (_indiceHistorico < _historicoPerguntas.Count - 1)
            {
                _indiceHistorico++;
                txtPergunta.Text = _historicoPerguntas[_indiceHistorico];
            }
            else
            {
                _indiceHistorico = _historicoPerguntas.Count;
                txtPergunta.Clear();
            }
        }

        private void dgvIncidentes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string numeroIncidente = dgvIncidentes.Rows[e.RowIndex].Cells["Number"].Value.ToString();

                using (FormAnotacoes frm = new FormAnotacoes(numeroIncidente))
                {
                    frm.ShowDialog();
                }
            }
        }
        #endregion

        #region Kernel Functions para IA

        [KernelFunction]
        [Description("Gera um arquivo Excel com os dados exatamente como estão visíveis na tabela da tela (colunas em português e filtros aplicados).")]
        public string ExportarTabelaParaExcel()
        {
            return (string)this.Invoke(new Func<string>(() =>
            {
                StringBuilder sb = new StringBuilder();
                AnotacaoDataService anotacaoDataService = new AnotacaoDataService(Properties.Settings.Default.UltimoCaminhoBanco);

                var colunasVisiveis = dgvIncidentes.Columns.Cast<DataGridViewColumn>()
                    .Where(x => x.Visible)
                    .OrderBy(x => x.DisplayIndex)
                    .ToList();

                // Cabeçalho: colunas visíveis + colunas da anotação
                var cabecalho = string.Join(",", colunasVisiveis.Select(x => x.HeaderText))
                                + ",Status Interno,Observação";
                sb.AppendLine(cabecalho);

                // varrendo as linhas
                foreach (DataGridViewRow row in dgvIncidentes.Rows)
                {
                    if (row.IsNewRow) continue;

                    string numeroIncidente = row.Cells["Number"].Value?.ToString();
                    var anotacao = anotacaoDataService.ObterDadosAnotacaoParaExportacao(numeroIncidente);

                    var valoresGrid = colunasVisiveis.Select(c =>
                    {
                        string val = row.Cells[c.Index].Value?.ToString() ?? "";
                        return val.Replace(",", "").Replace("\"", "").Replace("\r", " ").Replace("\n", " ");
                    }).ToList();

                    // adicionando dados da anotação
                    valoresGrid.Add(anotacao?.StatusInterno?.Replace(",", "").Replace("\"", "") ?? "");
                    valoresGrid.Add(anotacao?.Observacao?.Replace(",", "").Replace("\"", "").Replace("\r", " ").Replace("\n", " ") ?? "");

                    sb.AppendLine(string.Join(",", valoresGrid));
                }

                string csvFinal = sb.ToString();

                var excelPlugin = new ExcelPlugin(dgvIncidentes);
                excelPlugin.CriarExcelComDialogo("Exportacao_Incidentes.xlsx", csvFinal);

                return "Excel gerado com sucesso com os dados da tela e anotações.";
            }));
        }


        [KernelFunction]
        [Description("Gera um gráfico em uma janela separada. Tipos: 'pie' (pizza), 'bar' (barra). O parâmetro 'titulo' deve ser um resumo do que o gráfico representa.")]
        public string GerarGraficoJanelaSeparada(string tipo, string labelsCsv, string valoresCsv, string titulo)
        {
            return (string)this.Invoke(new Func<string>(() =>
            {
                try
                {
                    var popup = new FormGrafico();
                    popup.Size = new Size(800, 500);
                    popup.StartPosition = FormStartPosition.CenterScreen;

                    var plot = popup.Grafico.Plot;
                    plot.Clear();

                    // Processa dados recebidos da IA
                    string[] labels = labelsCsv.Split(',').Select(x => x.Trim().Replace("'", "")).ToArray();
                    double[] valores = valoresCsv.Split(',').Select(x => double.Parse(x.Trim())).ToArray();

                    // Paleta de cores moderna
                    var cores = new ScottPlot.Palettes.Category10();

                    // Renderização conforme o tipo
                    if (tipo.ToLower() == "pie")
                    {
                        var fatias = new List<ScottPlot.PieSlice>();
                        for (int i = 0; i < valores.Length; i++)
                        {
                            var fatia = new ScottPlot.PieSlice(valores[i], cores.GetColor(i));
                            fatia.Label = $"{labels[i]} ({valores[i]})";
                            fatias.Add(fatia);
                        }

                        var pie = plot.Add.Pie(fatias);
                        pie.ExplodeFraction = 0.05;
                        pie.SliceLabelDistance = 1.15;

                        plot.ShowLegend(ScottPlot.Alignment.MiddleRight);
                    }
                    else // Tipo: Bar
                    {
                        var listaDeBarras = new List<ScottPlot.Bar>();
                        for (int i = 0; i < valores.Length; i++)
                        {
                            listaDeBarras.Add(new ScottPlot.Bar()
                            {
                                Value = valores[i],
                                Position = i,
                                FillColor = cores.GetColor(i),
                                Label = labels[i]
                            });
                        }

                        var bars = plot.Add.Bars(listaDeBarras);

                        // Configura os nomes no eixo X
                        var ticks = labels.Select((txt, i) => new ScottPlot.Tick(i, txt)).ToArray();
                        plot.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(ticks);

                        plot.Axes.Bottom.Label.Text = "Categorias";
                        plot.Axes.Left.Label.Text = "Quantidade";
                    }

                    plot.Title(titulo);
                    plot.Axes.AutoScale();
                    popup.Grafico.Refresh();

                    popup.Show();

                    return $"Janela {titulo} aberta com sucesso.";
                }
                catch (Exception ex)
                {
                    return $"Erro técnico ao gerar gráfico: {ex.Message}";
                }
            }));
        }
        #endregion
    }
}
