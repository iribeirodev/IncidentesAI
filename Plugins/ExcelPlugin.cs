using ClosedXML.Excel;
using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Data;
using System.Text;

namespace IncidentesAI.Plugins;

public class ExcelPlugin
{
    private readonly DataGridView _grid;

    public ExcelPlugin(DataGridView grid)
    {
        _grid = grid;
    }

    [KernelFunction]
    [Description("Lê os dados visíveis na tabela. Use APENAS se os dados fornecidos no prompt inicial forem insuficientes.")]
    public string LerDadosDaTabela()
    {
        var sb = new StringBuilder();
        string resultado = "";

        _grid.Invoke(new MethodInvoker(() =>
        {
            var colunas = _grid.Columns.Cast<DataGridViewColumn>().ToList();
            sb.AppendLine(string.Join(",", colunas.Select(c => c.HeaderText)));

            // Limitamos a 30 para evitar que o retorno da função cause erro 422 na API
            foreach (DataGridViewRow row in _grid.Rows.Cast<DataGridViewRow>().Take(30))
            {
                if (row.IsNewRow) continue;
                var cells = row.Cells.Cast<DataGridViewCell>()
                    .Select(c => (c.Value?.ToString() ?? "").Replace(",", " ").Replace("\n", " "));
                sb.AppendLine(string.Join(",", cells));
            }
            resultado = sb.ToString();
        }));

        return resultado;
    }

    [KernelFunction]
    [Description("Cria um arquivo Excel a partir de dados CSV. O parâmetro 'limite' deve ser o número exato pedido pelo usuário.")]
    public string CriarExcelComDialogo(
        [Description("Sugestão de nome (ex: relatorio.xlsx)")] string nomeArquivoSugestao,
        [Description("Dados em CSV")] string dadosCsv,
        [Description("Número de registros solicitado")] int? limite = null)
    {
        string statusOperacao = "";

        _grid.Invoke(new MethodInvoker(() =>
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Arquivos Excel (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = nomeArquivoSugestao;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Dados_IA");
                            var todasAsLinhas = dadosCsv.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                            if (todasAsLinhas.Length > 0)
                            {
                                string cabecalho = todasAsLinhas[0];
                                var dadosSemCabecalho = todasAsLinhas.Skip(1).ToList();

                                // Aplica o corte de limite no C# (Garante que se pediu 5, terá 5)
                                var linhasParaProcessar = limite.HasValue
                                    ? dadosSemCabecalho.Take(limite.Value).ToList()
                                    : dadosSemCabecalho;

                                EscreverLinhaNoExcel(ws, 1, cabecalho);
                                for (int i = 0; i < linhasParaProcessar.Count; i++)
                                {
                                    EscreverLinhaNoExcel(ws, i + 2, linhasParaProcessar[i]);
                                }

                                ws.Columns().AdjustToContents();
                                ws.FirstRow().Style.Font.Bold = true;
                                ws.FirstRow().Style.Fill.BackgroundColor = XLColor.LightGray;

                                workbook.SaveAs(saveFileDialog.FileName);

                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(saveFileDialog.FileName) { UseShellExecute = true });

                                // RETORNO CURTO: Evita erro 422 na Mistral
                                statusOperacao = $"Sucesso: Planilha gerada com {linhasParaProcessar.Count} registros.";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        statusOperacao = $"Erro técnico ao gerar Excel: {ex.Message}";
                    }
                }
                else
                {
                    statusOperacao = "Cancelado: O usuário desistiu de salvar o arquivo.";
                }
            }
        }));

        return statusOperacao;
    }

    private void EscreverLinhaNoExcel(IXLWorksheet ws, int rowNumber, string linhaCsv)
    {
        var celulas = linhaCsv.Split(',');
        for (int c = 0; c < celulas.Length; c++)
        {
            ws.Cell(rowNumber, c + 1).Value = celulas[c].Trim().Replace("\"", "");
        }
    }
}