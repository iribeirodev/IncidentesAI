using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

public static class PanelEffects
{
    public static void AplicarHoverGradiente(
        Panel panel,
        Label lblDescricao,
        string descricao,
        Label lblTitulo)
    {
        typeof(Panel)
            .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
            .SetValue(panel, true, null);

        int alpha = 0;
        int alvo = 0;

        Color corOriginalTitulo = lblTitulo.ForeColor;
        Color corDestaque = Color.SteelBlue;

        Timer timer = new Timer();
        timer.Interval = 10;

        void AtivarHover()
        {
            alvo = 255;
            lblDescricao.Text = descricao;
            lblTitulo.ForeColor = corDestaque;
            timer.Start();
        }

        void DesativarHover()
        {
            alvo = 0;
            lblDescricao.Text = "";
            lblTitulo.ForeColor = corOriginalTitulo;
            timer.Start();
        }

        void ResetImediato()
        {
            timer.Stop();
            alpha = 0;
            alvo = 0;
            lblDescricao.Text = "";
            lblTitulo.ForeColor = corOriginalTitulo;
            panel.Invalidate();
        }

        timer.Tick += (s, e) =>
        {
            int velocidade = 30;
            if (alpha < alvo) alpha = Math.Min(alpha + velocidade, alvo);
            else if (alpha > alvo) alpha = Math.Max(alpha - velocidade, alvo);

            if (alpha == alvo) timer.Stop();
            panel.Invalidate();
        };

        panel.MouseEnter += (s, e) => AtivarHover();
        panel.MouseLeave += (s, e) => DesativarHover();

        // Resetar se o painel for clicado (evita ficar aceso ao abrir o Modal)
        panel.Click += (s, e) => ResetImediato();

        foreach (Control ctrl in panel.Controls)
        {
            ctrl.MouseEnter += (s, e) => AtivarHover();
            ctrl.MouseLeave += (s, e) => DesativarHover();
            ctrl.Click += (s, e) => ResetImediato(); // Aplica aos filhos também
        }

        panel.Paint += (s, e) =>
        {
            if (alpha <= 0) return;
            Rectangle rect = new Rectangle(0, panel.Height - 3, panel.Width, 3);

            // Gradiente do transparente para steelBlue
            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect,
                Color.FromArgb(alpha, Color.FromArgb(30, 30, 30)),
                Color.FromArgb(alpha, corDestaque),
                LinearGradientMode.Horizontal))
            {
                e.Graphics.FillRectangle(brush, rect);
            }
        };
    }
}
