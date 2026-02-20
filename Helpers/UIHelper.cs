using System.Reflection;

namespace IncidentesAI.Helpers;

public class UIHelper
{
    public static string ObterTituloApp()
        => Strings.TituloApp ?? "Incidentes AI";

    public static void MostrarAviso(string mensagem)
        => MessageBox.Show(mensagem, 
                                "Atenção", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);

    public static void MostrarErro(string mensagem)
        => MessageBox.Show(mensagem, 
                                "Erro", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);

    public static void MostrarSucesso(string mensagem)
        => MessageBox.Show(mensagem, 
                                "Sucesso", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

    public static void Executar(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            MostrarErro(ex.Message);
        }
    }
}
