using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;


namespace IncidentesAI.Helpers;

public static class LabelEffects
{
    public static void AplicarSombra(
        Label label,
        int offsetX = 2,
        int offsetY = 2,
        int sombraAlpha = 80)
    {
        label.AutoSize = false;
        label.DoubleBuffered(true);

        string textoOriginal = label.Text;
        label.Text = "";

        label.Paint += (s, e) =>
        {
            e.Graphics.SmoothingMode =
                System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            e.Graphics.TextRenderingHint =
                TextRenderingHint.ClearTypeGridFit;

            using (SolidBrush sombraBrush =
                   new SolidBrush(Color.FromArgb(sombraAlpha, Color.Black)))
            using (SolidBrush textoBrush =
                   new SolidBrush(label.ForeColor))
            {
                // sombra
                e.Graphics.DrawString(
                    textoOriginal,
                    label.Font,
                    sombraBrush,
                    offsetX,
                    offsetY);

                // texto principal
                e.Graphics.DrawString(
                    textoOriginal,
                    label.Font,
                    textoBrush,
                    0,
                    0);
            }
        };
    }

    // Ativar double buffer
    private static void DoubleBuffered(this Control control, bool enable)
    {
        typeof(Control)
            .GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)
            .SetValue(control, enable, null);
    }
}
