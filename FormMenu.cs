using ScottPlot.Palettes;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace IncidentesAI;

public partial class FormMenu : Form
{
    private readonly Color DefaultMenuItemColor;
    private readonly string SelectedMenuItemColor;
    private readonly string CorBordaSuperior;
    private readonly string CorBordaInferior;
    private Label lblHint;

    public FormMenu()
    {
        InitializeComponent();

        DefaultMenuItemColor = Color.DimGray;
        SelectedMenuItemColor = "#BFBFB4";
        CorBordaSuperior = "#47442A";
        CorBordaInferior = "#7A7A5C";


        lblTitulo.Text = "ServiceNow AI Insights and Analytics (Incidentes AI)";
        CriarHint();
    }

    private void ExibirFormulario(object sender, EventArgs e)
    {
        PictureBox pic = sender as PictureBox;
        if (pic != null)
        {
            switch (pic.Name)
            {
                case "ListaIncidentes":
                    FormMain formMain = new FormMain();
                    formMain.ShowDialog();
                    break;
                case "Prompt":
                    FormPrompt formPrompt = new FormPrompt();
                    formPrompt.ShowDialog();
                    break;
                case "Configuracoes":
                    FormConfig formConfig = new FormConfig();
                    formConfig.ShowDialog();
                    break;
            }
        }
    }

    private void EstilizarBordaFlowLayout(object sender, PaintEventArgs e)
    {
        Color corBorda = ColorTranslator.FromHtml(CorBordaSuperior); 
        Color corBordaInferior = ColorTranslator.FromHtml(CorBordaInferior);
        int espessura = 1;

        ControlPaint.DrawBorder(e.Graphics, flowLayoutPanel1.ClientRectangle,
            corBorda, espessura, ButtonBorderStyle.Solid, // Esquerda
            corBorda, espessura, ButtonBorderStyle.Solid, // Cima
            corBordaInferior, espessura, ButtonBorderStyle.Solid, // Direita
            corBordaInferior, espessura, ButtonBorderStyle.Solid); // Baixo
    }

    private async void DestacarMenuItem(object sender, EventArgs e)
    {
        if (sender is PictureBox pic)
        {
            LimparTodosDestaques();

            Color baseColor = ColorTranslator.FromHtml(SelectedMenuItemColor);

            // Loop de animação
            for (int alpha = 0; alpha <= 40; alpha += 4)
            {
                // Verificação de segurança: se o mouse já saiu durante o delay, interrompe
                try
                {
                    if (!pic.ClientRectangle.Contains(pic.PointToClient(Control.MousePosition)))
                        break;
                }
                catch{}

                pic.BackColor = Color.FromArgb(alpha, baseColor);

                if (lblHint != null)
                {
                    lblHint.ForeColor = Color.FromArgb(alpha, baseColor);
                    lblHint.Text = pic.Tag.ToString();
                }

                await Task.Delay(5);
            }
        }
    }

    private void EsmaecerMenuItem(object sender, EventArgs e)
    {
        PictureBox pic = sender as PictureBox;
        if (pic != null)
        {
            pic.BackColor = DefaultMenuItemColor;
            lblHint.ForeColor = DefaultMenuItemColor;
            lblHint.Text = string.Empty;
        }
            
    }

    // Método auxiliar para garantir que apenas um fique ativo
    private void LimparTodosDestaques()
    {
        var menus = new[] { ListaIncidentes, Prompt, Configuracoes, Sair };
        foreach (var item in menus)
            item.BackColor = DefaultMenuItemColor;
    }

    private void CriarHint()
    {
        lblHint = new Label();
        lblHint.Text = "";

        lblHint.TextAlign = ContentAlignment.TopCenter;
        lblHint.Dock = DockStyle.Fill;

        lblHint.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        lblHint.ForeColor = Color.Orange;

        tableLayoutPanel1.Controls.Add(lblHint, 1, 2); // 3a. linha, 2a. coluna
    }

    private void lblIncidentes_Click(object sender, EventArgs e)
    {
        FormMain formMain = new FormMain();
        formMain.ShowDialog();
    }

    private void lblConfiguracoes_Click(object sender, EventArgs e)
    {
        FormConfig formConfig = new FormConfig();
        formConfig.ShowDialog();
    }

    private void FormMenu_Paint(object sender, PaintEventArgs e)
    {
        using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            this.ClientRectangle,
            Color.White,
            Color.FromArgb(30, 255, 215, 0),
            90F))
        {
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }
    }

    private void Sair_Click(object sender, EventArgs e) => Application.Exit();
}
