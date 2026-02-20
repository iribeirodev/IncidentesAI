namespace IncidentesAI
{
    public partial class FormGrafico : Form
    {
        public ScottPlot.WinForms.FormsPlot Grafico => formsPlot1;

        public FormGrafico()
        {
            InitializeComponent();

            // Cores de fundo (Dark Mode)
            formsPlot1.Plot.FigureBackground.Color = ScottPlot.Color.FromColor(Color.FromArgb(30, 30, 30));
            formsPlot1.Plot.DataBackground.Color = ScottPlot.Color.FromColor(Color.FromArgb(140, 139, 144));

            // Remove os eixos (limpa os números das bordas)
            formsPlot1.Plot.Axes.Frameless();

            formsPlot1.Plot.Axes.Title.Label.Text = "Incidentes por Status";
            formsPlot1.Plot.Axes.Title.Label.ForeColor = ScottPlot.Color.FromColor(Color.White);
            formsPlot1.Plot.Axes.Title.Label.FontSize = 18;

            formsPlot1.Plot.Legend.IsVisible = true;
            formsPlot1.Plot.Legend.FontColor = ScottPlot.Color.FromColor(Color.White);
            formsPlot1.Plot.Legend.BackgroundColor = ScottPlot.Color.FromColor(Color.FromArgb(45, 45, 48));
            formsPlot1.Plot.Legend.OutlineColor = ScottPlot.Color.FromColor(Color.Gray);

            formsPlot1.Refresh();
        }
    }
}
