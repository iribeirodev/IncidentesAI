namespace IncidentesAI;

public partial class FormCalendar : Form
{
    public string DataSelecionada { get; set; } = "";

    public FormCalendar()
    {
        InitializeComponent();
    }

    private void lblClose_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void calendarioMensal_DateSelected(object sender, DateRangeEventArgs e)
    {
        DataSelecionada = calendarioMensal.SelectionStart.ToString("dd/MM/yyyy");
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    public void SetDataInicial(string dataTexto)
    {
        // Tenta converter a string para DateTime para o componente entender
        if (DateTime.TryParseExact(dataTexto, "dd/MM/yyyy",
            new System.Globalization.CultureInfo("pt-BR"),
            System.Globalization.DateTimeStyles.None, out DateTime dataValida))
        {
            calendarioMensal.SelectionStart = dataValida;
            calendarioMensal.SelectionEnd = dataValida; // Garante que apenas um dia fique focado
        }
    }
}
