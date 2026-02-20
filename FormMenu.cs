using IncidentesAI.Helpers;

namespace IncidentesAI;

public partial class FormMenu : Form
{
    private Color CorDefaultPanel;

    private Dictionary<string, Func<Form>> Routes = new Dictionary<string, Func<Form>> {
    { "Panel01", () => new FormMain() },
    { "Panel02", () => new FormPrompt() },
    { "Panel03", () => new FormConfig() }};

    public FormMenu()
    {
        InitializeComponent();

        CorDefaultPanel = Panel01.BackColor;
        lblTitulo.Text = UIHelper.ObterTituloApp();

        // Efeitos de panel
        PanelEffects.AplicarHoverGradiente(Panel01, lblDescricao, Panel01.Tag.ToString(), Titulo01);
        PanelEffects.AplicarHoverGradiente(Panel02, lblDescricao, Panel02.Tag.ToString(), Titulo02);
        PanelEffects.AplicarHoverGradiente(Panel03, lblDescricao, Panel03.Tag.ToString(), Titulo03);
    }

    private void ExibirFormulario(object sender, EventArgs e)
    {
        var controle = sender as Control;
        string nome = (controle is Panel p ? p.Name : controle.Parent?.Name);

        if (nome != null && Routes.TryGetValue(nome, out var exibirForm))
        {
            // Forçar o Invalidate para "apagar" o brilho antes de abrir o modal
            if (controle is Panel pnl) pnl.Invalidate();
            else controle.Parent?.Invalidate();

            using (var frm = exibirForm())
            {
                frm.ShowDialog();
            }

            // Ao voltar, garante que a descrição limpe
            lblDescricao.Text = "";
        }
    }

    private void lblIncidentes_Click(object sender, EventArgs e)
        => new FormMain().ShowDialog();

    private void lblConfiguracoes_Click(object sender, EventArgs e)
        => new FormConfig().ShowDialog();

    private void Sair_Click(object sender, EventArgs e)
        => Application.Exit();

    private void FormMenu_Paint(object sender, PaintEventArgs e)
    {
        // Habilitar anti-aliasing para suavizar as bordas do texto
        e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
    }
}
