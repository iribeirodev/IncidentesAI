using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace IncidentesAI;

public partial class FormMenu : Form
{
    private readonly Color SelectedMenuItemColor;


    public FormMenu()
    {
        InitializeComponent();
        SelectedMenuItemColor = Color.Gold;

        SetCustomFont();
    }

    private void SetCustomFont()
    {
        byte[] fontData = Properties.Resources.Roboto_Medium;
        IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
        Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

        PrivateFontCollection pfc = new PrivateFontCollection();
        pfc.AddMemoryFont(fontPtr, fontData.Length);
        Marshal.FreeCoTaskMem(fontPtr);

        btnIncidentes.Font = new Font(pfc.Families[0], 10, FontStyle.Bold);
        btnConfiguracoes.Font = new Font(pfc.Families[0], 10, FontStyle.Bold);
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

    private void btnIncidentes_Click(object sender, EventArgs e)
    {
        btnIncidentes.IconColor = Color.Gold;

        FormMain formMain = new FormMain();
        formMain.ShowDialog();

        btnIncidentes.IconColor = Color.White;
    }

    private void btnConfiguracoes_Click(object sender, EventArgs e)
    {
        btnConfiguracoes.IconColor = SelectedMenuItemColor;

        FormConfig formConfig = new FormConfig();
        formConfig.ShowDialog();

        btnConfiguracoes.IconColor = Color.White;
    }

    private void btnConfiguracoes_MouseEnter(object sender, EventArgs e)
    {

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
}
