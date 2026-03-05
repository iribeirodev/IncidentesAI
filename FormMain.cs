using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Reflection;
using System.Text;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using IncidentesAI.Helpers;
using IncidentesAI.Model;
using IncidentesAI.Plugins;
using IncidentesAI.Services;


namespace IncidentesAI;

public partial class FormMain : Form
{
    /// <summary>
    /// Instância principal do Kernel da IA, responsável por processar prompts e invocar plugins. 
    /// </summary>
    private Kernel _kernel;

    /// <summary>
    /// Lista de perguntas feitas pelo usuário, carregadas do histórico e atualizadas em tempo real. 
    /// </summary>
    private List<string> _historicoPerguntas = new List<string>();

    /// <summary>
    /// Índice atual dentro da lista de histórico de perguntas, usado para navegação (up/down). 
    /// </summary>
    private int _indiceHistorico = -1;

    /// <summary>
    /// Caminho completo do arquivo de histórico de perguntas(historico.txt). 
    /// </summary>
    private readonly string _caminhoArquivoHistorico = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "historico.txt");

    /// <summary>
    /// Quantidade de incidentes a considerar ao carregar dados do banco. 
    /// </summary>
    private int _numeroIncidentesConsiderar;

    /// <summary>
    /// Lista original de todos os incidentes carregados da base de dados. Usada como fonte principal para aplicar filtros. 
    /// </summary>
    private List<Incidente> _todosIncidentes;

    /// <summary>
    /// Flag usada para alternar a ordenação ascendente/descendente na coluna de datas. 
    /// </summary>
    private bool sortAscending = true;

    /// <summary>
    /// Flag usada para sinalizar que os dados da grid estão filtrados.
    /// </summary>
    private bool isFiltered = false;

    #region Construtor
    public FormMain()
    {
        InitializeComponent();

        chkFiltrarData.Checked = false;
        _numeroIncidentesConsiderar = Properties.Settings.Default.NumeroIncidentes;

        HabilitarCalendario(false);

        CarregarHistoricoDoArquivo();

        SetupKernel();

        typeof(DataGridView).InvokeMember("DoubleBuffered", BindingFlags.NonPublic |
            BindingFlags.Instance | BindingFlags.SetProperty, null, dgvIncidentes, new object[] { true });
    }
    #endregion

    #region Métodos Públicos

    /// <summary>
    /// Configura e inicializa o Kernel da IA utilizado no sistema.
    /// Carrega variáveis de ambiente (.env) para obter credenciais e parâmetros
    /// do modelo Mistral, adiciona plugins (Excel e o próprio FormMain)
    /// e constrói a instância final do Kernel.
    /// </summary>
    private void SetupKernel()
    {
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

    /// <summary>
    /// Carrega o histórico de perguntas do arquivo de texto configurado.
    /// Se o arquivo existir, lê todas as linhas e armazena na lista interna
    /// (_historicoPerguntas), atualizando também o índice de navegação.
    /// </summary>
    private void CarregarHistoricoDoArquivo()
    {
        if (File.Exists(_caminhoArquivoHistorico))
        {
            _historicoPerguntas = File.ReadAllLines(_caminhoArquivoHistorico).ToList();
            _indiceHistorico = _historicoPerguntas.Count;
        }
    }

    /// <summary>
    /// Salva uma pergunta no histórico interno e no arquivo de texto.
    /// Ignora entradas nulas ou em branco. Atualiza a lista de perguntas
    /// (_historicoPerguntas), reposiciona o índice de navegação para o final
    /// e grava a nova pergunta no arquivo configurado.
    /// </summary>
    /// <param name="pergunta">Texto da pergunta a ser registrada.</param>
    private void SalvarPerguntaNoHistorico(string pergunta)
    {
        if (string.IsNullOrWhiteSpace(pergunta)) return;

        // Adiciona na lista e reseta o índice para o final
        _historicoPerguntas.Add(pergunta);
        _indiceHistorico = _historicoPerguntas.Count;

        // Salva no arquivo (Append)
        File.AppendAllLines(_caminhoArquivoHistorico, new[] { pergunta });
    }

    /// <summary>
    /// Carrega os incidentes do banco de dados configurado e exibe no DataGridView.
    /// Obtém a lista completa de incidentes através do serviço de dados,
    /// armazena na variável interna (_todosIncidentes) e define como fonte da grid.
    /// Também prepara os combos de filtro com valores únicos do banco.
    /// </summary>
    /// <remarks>
    /// Em caso de erro na leitura do banco ou carregamento dos dados,
    /// uma mensagem de erro é exibida ao usuário.
    /// </remarks>
    public void CarregarDados()
    {
        try
        {
            string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;
            var dataService = new IncidenteDataService(caminhoDb);
            _todosIncidentes = dataService.ObterTodosIncidentes(_numeroIncidentesConsiderar);

            dgvIncidentes.AlternatingRowsDefaultCellStyle.BackColor = Color.Empty;

            dgvIncidentes.AutoGenerateColumns = false;
            dgvIncidentes.DataSource = _todosIncidentes;


            PreencherCombosFiltro();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Erro ao carregar dados: " + ex.Message);
        }
    }

    /// <summary>
    /// Preenche os combos de filtro da tela com valores únicos obtidos do banco de dados.
    /// Carrega itens de configuração, status e solicitantes (callers),
    /// adicionando a opção padrão "--- Todos ---" em cada combo.
    /// </summary>
    /// <remarks>
    /// Caso o caminho do banco de dados não esteja configurado ou o arquivo não exista,
    /// o método retorna sem alterações. Em caso de erro durante a leitura,
    /// uma mensagem de erro é exibida ao usuário.
    /// </remarks>
    private void PreencherCombosFiltro()
    {
        string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;

        if (string.IsNullOrEmpty(caminhoDb) || !System.IO.File.Exists(caminhoDb))
            return;

        try
        {
            var dataService = new IncidenteDataService(caminhoDb);

            var itensCI = dataService.ObterValoresUnicos("ConfigurationItem");
            cboConfigurationItem.Items.Clear();
            cboConfigurationItem.Items.Add("--- Todos ---");
            cboConfigurationItem.Items.AddRange(itensCI.ToArray());
            cboConfigurationItem.SelectedIndex = 0;

            var itensStatus = dataService.ObterValoresUnicos("State");
            cboStatus.Items.Clear();
            cboStatus.Items.Add("--- Todos ---");
            cboStatus.Items.AddRange(itensStatus.ToArray());
            cboStatus.SelectedIndex = 0;

            var itensCaller = dataService.ObterValoresUnicos("Caller");
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

    /// <summary>
    /// Aplica os filtros definidos na interface sobre a lista de incidentes carregada.
    /// Os filtros podem incluir: número do incidente, descrição, item de configuração,
    /// status, solicitante (caller) e período de criação.
    /// </summary>
    /// <remarks>
    /// - Se nenhum filtro estiver ativo, restaura a lista original de incidentes.
    /// - Atualiza a fonte de dados do DataGridView com os resultados filtrados.
    /// - Exibe na label a quantidade de registros encontrados ou uma mensagem
    /// indicando que nenhum registro foi localizado.
    /// </remarks>
    private void FiltrarDados()
    {
        if (_todosIncidentes == null) return;

        IEnumerable<Incidente> filtrados = _todosIncidentes;

        string num = txtNumber.Text.Trim();
        string desc = txtShortDescription.Text.Trim();

        bool temFiltro =
            !string.IsNullOrEmpty(num) ||
            !string.IsNullOrEmpty(desc) ||
            cboConfigurationItem.SelectedIndex > 0 ||
            cboStatus.SelectedIndex > 0 ||
            cboCaller.SelectedIndex > 0 ||
            chkFiltrarData.Checked;

        if (!temFiltro)
        {
            // Nenhum filtro → volta lista original
            dgvIncidentes.DataSource = _todosIncidentes;
            lblCntFilter.Text = "";
            return;
        }

        if (!string.IsNullOrEmpty(num))
            filtrados = filtrados.Where(i => i.Number != null &&
                                             i.Number.Contains(num, StringComparison.OrdinalIgnoreCase));

        if (!string.IsNullOrEmpty(desc))
            filtrados = filtrados.Where(i => i.ShortDescription != null &&
                                             i.ShortDescription.Contains(desc, StringComparison.OrdinalIgnoreCase));

        if (cboConfigurationItem.SelectedIndex > 0)
            filtrados = filtrados.Where(i => i.ConfigurationItem == cboConfigurationItem.Text);

        if (cboStatus.SelectedIndex > 0)
            filtrados = filtrados.Where(i => i.State == cboStatus.Text);

        if (cboCaller.SelectedIndex > 0)
            filtrados = filtrados.Where(i => i.Caller == cboCaller.Text);

        if (chkFiltrarData.Checked &&
            DateTime.TryParse(txtDtInicio.Text, out var dtInicio) &&
            DateTime.TryParse(txtDtFim.Text, out var dtFim))
        {
            filtrados = filtrados.Where(i => i.Created >= dtInicio && i.Created <= dtFim);
        }

        var listaFiltrada = filtrados.ToList();
        dgvIncidentes.DataSource = listaFiltrada;

        isFiltered = true;

        // Atualização da Label de Contagem
        if (!listaFiltrada.Any())
        {
            lblCntFilter.Text = "Nenhum registro encontrado.";
            lblCntFilter.ForeColor = Color.LightCoral;
        }
        else
        {
            lblCntFilter.Text = $"Encontrado: {listaFiltrada.Count} de {_todosIncidentes.Count}";
            lblCntFilter.ForeColor = Color.SteelBlue;
        }
    }

    /// <summary>
    /// Adiciona uma entrada formatada no histórico de conversas exibido na interface.
    /// Inclui o horário atual, o autor da mensagem e o texto fornecido.
    /// Suporta trechos em negrito delimitados por **.
    /// </summary>
    /// <param name="autor">Nome do autor da mensagem (ex.: Usuário ou IA).</param>
    /// <param name="texto">Conteúdo da mensagem a ser exibida.</param>
    /// <param name="corTexto">Cor usada para renderizar o texto da mensagem.</param>
    /// <remarks>
    /// O método insere o horário em cinza, o autor seguido de dois pontos,
    /// e aplica formatação alternada (negrito/regular) conforme delimitadores **.
    /// Ao final, rola automaticamente o controle para mostrar a nova entrada.
    /// </remarks>
    private void AdicionarTextoFormatado(
        string autor, 
        string texto, 
        Color corTexto)
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

    /// <summary>
    /// Abre uma janela de calendário para seleção de data, vinculada ao campo de início ou fim
    /// conforme o botão clicado. Posiciona a janela próximo ao botão na tela e,
    /// ao confirmar a seleção, atualiza o campo alvo com a data escolhida.
    /// </summary>
    /// <param name="sender">O botão que disparou o evento (esperado: btnShowCalendarInicio ou btnShowCalendarFim).</param>
    /// <param name="e">Argumentos do evento de clique.</param>
    /// <remarks>
    /// - Se o campo já possuir uma data, ela é usada como inicial no calendário.
    /// - Após a seleção, valida se a data de início não é maior que a data de fim.
    /// - Em caso de inconsistência, exibe aviso e limpa o campo.
    /// </remarks>
    private void AbrirCalendario(object sender, EventArgs e)
    {
        Button btnClicado = sender as Button;
        if (btnClicado == null || btnClicado.Tag == null) return;

        string whichButton = btnClicado.Tag.ToString();
        TextBox txtAlvo = (whichButton == "DataInicio") ? txtDtInicio : txtDtFim;

        using (FormCalendar _formCalendar = new FormCalendar())
        {
            _formCalendar.StartPosition = FormStartPosition.Manual;

            if (!string.IsNullOrWhiteSpace(txtAlvo.Text))
                _formCalendar.SetDataInicial(txtAlvo.Text);

            Point localizacaoNaTela = btnClicado.PointToScreen(Point.Empty);
            _formCalendar.Left = localizacaoNaTela.X;
            _formCalendar.Top = localizacaoNaTela.Y + btnClicado.Height;

            if (_formCalendar.ShowDialog() == DialogResult.OK)
            {
                txtAlvo.Text = _formCalendar.DataSelecionada;

                string formato = "dd/MM/yyyy";
                CultureInfo culturaBR = new CultureInfo("pt-BR");

                bool inicioValido = DateTime.TryParseExact(txtDtInicio.Text, formato, culturaBR, DateTimeStyles.None, out DateTime dataInicio);
                bool fimValido = DateTime.TryParseExact(txtDtFim.Text, formato, culturaBR, DateTimeStyles.None, out DateTime dataFim);

                if (inicioValido && fimValido)
                {
                    if (dataInicio > dataFim)
                    {
                        UIHelper.MostrarAviso("A data de início não pode ser maior que a data de fim.");
                        txtAlvo.Clear();
                    }
                }
            }
        }
    }

    /// <summary>
    /// Habilita ou desabilita os campos de data e os botões de calendário
    /// utilizados no filtro por período de criação dos incidentes.
    /// </summary>
    /// <param name="habilitado">
    /// Define se os controles devem estar ativos (true) ou desativados (false).
    /// </param>
    /// <remarks>
    /// Quando desabilitado, os campos de data não podem ser editados e os botões
    /// de seleção de calendário ficam indisponíveis.
    /// </remarks>
    private void HabilitarCalendario(bool habilitado)
    {
        txtDtInicio.Enabled = habilitado;
        txtDtFim.Enabled = habilitado;
        btnShowCalendarInicio.Enabled = habilitado;
        btnShowCalendarFim.Enabled = habilitado;
    }
    #endregion

    #region Eventos de UI
    private void FormMain_Load(object sender, EventArgs e)
    {
        timerFade.Start();
        CarregarDados();
    }

    private void btnFiltrar_Click(object sender, EventArgs e) => FiltrarDados();

    private void btnLimpar_Click(object sender, EventArgs e)
    {
        txtNumber.Text = "";
        txtShortDescription.Text = "";

        cboConfigurationItem.SelectedIndex = 0;
        cboStatus.SelectedIndex = 0;
        cboCaller.SelectedIndex = 0;

        chkFiltrarData.Checked = false;

        FiltrarDados();

        isFiltered = false;
    }

    private void chkFiltrarData_CheckedChanged(object sender, EventArgs e)
    {
        // Habilita/Desabilita os calendários
        if (chkFiltrarData.Checked)
        {
            chkFiltrarData.ForeColor = Color.SteelBlue;
            chkFiltrarData.Text = "Filtrando por período:";

            HabilitarCalendario(true);
        }
        else
        {
            chkFiltrarData.ForeColor = Color.Silver;
            chkFiltrarData.Text = "Filtrar por período de criação";

            HabilitarCalendario(false);

            txtDtInicio.Clear();
            txtDtFim.Clear();
        }
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
        AdicionarTextoFormatado("Usuário", userPrompt, Color.Orange);

        btnProcessar.Enabled = false;
        lblStatus.Text = "Consultando IA...";
        Cursor = Cursors.WaitCursor;

        try
        {
            string caminhoDb = Properties.Settings.Default.UltimoCaminhoBanco;
            var dataService = new IncidenteDataService(caminhoDb);

            // Verifica se é pergunta de ferramenta
            string promptLower = userPrompt.ToLower();

            bool perguntaTooling =
                promptLower.Contains("gráfico") ||
                promptLower.Contains("grafico") ||
                promptLower.Contains("pizza") ||
                promptLower.Contains("barras") ||
                promptLower.Contains("chart");

            // Só envia contexto se for análise textual
            string contextoDados = "";
            if (isFiltered)
            {
                var listaFiltrada = (List<Incidente>)dgvIncidentes.DataSource;
                contextoDados = dataService.ObterContextoFiltradoParaIA(listaFiltrada);
            } else
            {
                if (!perguntaTooling)
                    contextoDados = dataService.ObterContextoParaIA(_numeroIncidentesConsiderar);
            }

            string systemMessage = Properties.Settings.Default.PromptIA;

            StringBuilder fullPrompt = new StringBuilder();
            fullPrompt.AppendLine("### INSTRUÇÕES DE SISTEMA ###");
            fullPrompt.AppendLine(systemMessage);
            fullPrompt.AppendLine("\n### DADOS DOS TICKETS (CONTEXTO) ###");
            fullPrompt.AppendLine(contextoDados);
            fullPrompt.AppendLine("\n### PERGUNTA DO USUÁRIO ###");
            fullPrompt.AppendLine(userPrompt);

            var settings = new OpenAIPromptExecutionSettings
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                Temperature = 0.1
            };

            var arguments = new KernelArguments(settings);

            // Tentamos chamar a IA algumas vezes caso o limite de requisições seja atingido. 
            // Se der erro de "rate limit exceeded", esperamos alguns segundos e tentamos de novo. 
            // A cada tentativa o tempo de espera aumenta (2s → 4s → 8s), até no máximo 3 tentativas.
            int maxTentativas = 3;
            int delayMs = 2000;
            for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
            {
                try
                {
                    var resultado = await _kernel.InvokePromptAsync(fullPrompt.ToString(), arguments);
                    string respostaIA = resultado.ToString().Trim();

                    lblStatus.Text = "Pronto!";
                    AdicionarTextoFormatado("IA", respostaIA, Color.White);
                    txtPergunta.Clear();
                    break;
                }
                catch (HttpOperationException httpEx)
                {
                    if (httpEx.ResponseContent.Contains("rate limit exceeded"))
                    {
                        if (tentativa == maxTentativas)
                        {
                            MessageBox.Show("Limite de requisições atingido. Tente novamente mais tarde.");
                            lblStatus.Text = "Rate limit excedido.";
                        }
                        else
                        {
                            lblStatus.Text = $"Rate limit excedido, aguardando {delayMs / 1000}s antes da nova tentativa...";
                            await Task.Delay(delayMs);
                            delayMs *= 2; // espera exponencial
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Erro na API Mistral:\n{httpEx.ResponseContent}");
                        lblStatus.Text = "Erro na API.";
                        break;
                    }
                }
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
        formPrompt.IsReadOnly = true;
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
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            string numeroIncidente = dgvIncidentes.Rows[e.RowIndex].Cells["Number"].Value.ToString();

            using (FormAnotacoes frm = new FormAnotacoes(numeroIncidente))
                frm.ShowDialog();

        }
    }

    private void dgvIncidentes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
        string columnName = dgvIncidentes.Columns[e.ColumnIndex].Name;

        // só trata a coluna de data formatada
        if (columnName == "CreatedFormatado")
        {
            var incidentes = dgvIncidentes.DataSource as List<Incidente>;
            if (incidentes == null) return;

            List<Incidente> ordenados;

            if (sortAscending)
            {
                ordenados = incidentes.OrderBy(i => i.Created).ToList();
                sortAscending = false;
            }
            else
            {
                ordenados = incidentes.OrderByDescending(i => i.Created).ToList();
                sortAscending = true;
            }

            dgvIncidentes.DataSource = ordenados;
        }
    }

    private void dgvIncidentes_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
    {
        // desenha o número da linha no cabeçalho
        var grid = sender as DataGridView;
        var rowIdx = (e.RowIndex + 1).ToString();

        var centerFormat = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };

        Rectangle headerBounds = new Rectangle(
            e.RowBounds.Left,
            e.RowBounds.Top,
            grid.RowHeadersWidth,
            e.RowBounds.Height);

        e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText,
            headerBounds, centerFormat);
    }

    private void timerFade_Tick(object sender, EventArgs e)
    {
        if (this.Opacity < 1)
            this.Opacity += 0.05;
        else
            timerFade.Stop();
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
    [Description("Gera gráfico agrupando incidentes visíveis por um campo. Campos válidos: State, AssignedTo, Caller, ConfigurationItem.")]
    public string GerarGraficoPorCampo(
        string tipo,
        string campo,
        string titulo,
        int? topN = null)
    {
        return (string)this.Invoke(new Func<string>(() =>
        {
            var incidentes = dgvIncidentes.Rows
                                        .Cast<DataGridViewRow>()
                                        .Where(r => !r.IsNewRow)
                                        .Select(r => r.Cells[campo].Value?.ToString())
                                        .Where(v => !string.IsNullOrWhiteSpace(v));

            int limite = topN ?? 10;
            limite = Math.Clamp(limite, 1, 50);

            var agrupado = incidentes
                    .GroupBy(v => v)
                    .Select(g => new { Label = g.Key, Total = g.Count() })
                    .OrderByDescending(x => x.Total)
                    .Take(limite)
                    .ToList();

            string labels = string.Join(",", agrupado.Select(x => x.Label));
            string valores = string.Join(",", agrupado.Select(x => x.Total));

            return GerarGraficoJanelaSeparada(tipo, labels, valores, titulo);
        }));
    }

    [KernelFunction]
    [Description("Gera um gráfico em uma janela separada. Tipos: 'pie' (pizza), 'bar' (barra). O parâmetro 'titulo' deve ser um resumo do que o gráfico representa.")]
    public string GerarGraficoJanelaSeparada(
        string tipo, 
        string labelsCsv, 
        string valoresCsv, 
        string titulo)
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

    [KernelFunction]
    [Description("Retorna o número exato de incidentes visíveis na tabela da tela.")]
    public string ObterTotalIncidentes()
    {
        return (string)this.Invoke(new Func<string>(() =>
        {
            // Conta diretamente as linhas do DataGridView
            int total = dgvIncidentes.Rows
                .Cast<DataGridViewRow>()
                .Count(r => !r.IsNewRow);

            if (total == 0) return "Não há nenhum incidente no contexto";

            return total > 1 ? $"Existem {total} incidentes no contexto fornecido."
                        : $"Existe 1 incidente no contexto fornecido.";
        }));
    }
    #endregion

}
