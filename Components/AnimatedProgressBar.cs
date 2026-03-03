using System.Drawing.Drawing2D;
using Timer = System.Windows.Forms.Timer;

namespace IncidentesAI.Components;

public class AnimatedProgressBar : ProgressBar
{
    private Timer animationTimer;
    private int targetValue;
    private int velocidadeAnimacaoMs = 1000;

    public AnimatedProgressBar()
    {
        this.SetStyle(ControlStyles.UserPaint, true);
        this.ForeColor = Color.Black;
        this.BackColor = Color.Gray;

        animationTimer = new Timer();
        animationTimer.Interval = velocidadeAnimacaoMs;
        animationTimer.Tick += AnimateStep;
    }

    public void SetValueAnimated(int value)
    {
        targetValue = Math.Min(Maximum, Math.Max(Minimum, value));
        animationTimer.Start();
    }

    private void AnimateStep(object sender, EventArgs e)
    {
        if (Value < targetValue)
        {
            Value += Math.Min(1, targetValue - Value); // suaviza subida
        }
        else if (Value > targetValue)
        {
            Value -= Math.Min(1, Value - targetValue); // suaviza descida
        }
        else
        {
            animationTimer.Stop();
        }
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = this.ClientRectangle;
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Fundo branco
        using (SolidBrush brush = new SolidBrush(this.BackColor))
        {
            e.Graphics.FillRectangle(brush, rect);
        }

        // Área preenchida proporcional ao valor
        double percent = (double)Value / Maximum;
        Rectangle progressRect = new Rectangle(rect.X, rect.Y, (int)(rect.Width * percent), rect.Height);

        if (progressRect.Width > 0)
        {
            using (SolidBrush brush = new SolidBrush(this.ForeColor))
            {
                e.Graphics.FillRectangle(brush, progressRect);
            }
        }

        // Borda preta
        using (Pen pen = new Pen(Color.Black, 2))
        {
            e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 1, this.Height - 1);
        }

        // Texto centralizado (percentual)
        string text = $"{(int)(percent * 100)}%";
        using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
        using (SolidBrush brush = new SolidBrush(Color.Black))
        {
            SizeF textSize = e.Graphics.MeasureString(text, font);
            e.Graphics.DrawString(text, font, brush,
                (Width - textSize.Width) / 2,
                (Height - textSize.Height) / 2);
        }
    }

    private GraphicsPath RoundedRect(Rectangle bounds, int radius)
    {
        int diameter = radius * 2;
        Size size = new Size(diameter, diameter);
        Rectangle arc = new Rectangle(bounds.Location, size);
        GraphicsPath path = new GraphicsPath();

        path.AddArc(arc, 180, 90);
        arc.X = bounds.Right - diameter;
        path.AddArc(arc, 270, 90);
        arc.Y = bounds.Bottom - diameter;
        path.AddArc(arc, 0, 90);
        arc.X = bounds.Left;
        path.AddArc(arc, 90, 90);
        path.CloseFigure();

        return path;
    }
}

