using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IncidentesAI;

public partial class FormMenu : Form
{
    private readonly Color MenuBackColor;
    private readonly Color MenuHighLightColor;


    public FormMenu()
    {
        InitializeComponent();
        MenuBackColor = lblConfiguracoes.BackColor;
        MenuHighLightColor = Color.FromArgb(200, 168, 137, 5);

    }

    private void OnMenuMouseHover(object sender, EventArgs e)
    {
        Label menu = sender as Label;
        if (menu != null)
        {
            menu.BackColor = MenuHighLightColor;
        }
    }

    private void OnMenuMouseLeave(object sender, EventArgs e)
    {
        Label menu = sender as Label;
        if (menu != null)
        {
            menu.BackColor = MenuBackColor;
        }
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
}
