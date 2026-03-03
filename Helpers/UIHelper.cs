namespace IncidentesAI.Helpers;

/// <summary>
/// Classe auxiliar para interações com a interface do usuário.
/// Fornece métodos para exibir mensagens de aviso, erro, sucesso,
/// confirmação e executar ações com tratamento de exceções.
/// </summary>
public class UIHelper
{
    /// <summary>
    /// Obtém o título da aplicação a partir dos recursos.
    /// Se não estiver definido, retorna "Incidentes AI".
    /// </summary>
    /// <returns>Título da aplicação.</returns>
    public static string ObterTituloApp()
        => Strings.TituloApp ?? "Incidentes AI";

    /// <summary>
    /// Exibe uma mensagem de aviso ao usuário.
    /// </summary>
    /// <param name="mensagem">Texto da mensagem a ser exibida.</param>
    public static void MostrarAviso(string mensagem)
        => MessageBox.Show(mensagem, 
                                "Atenção", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Warning);

    /// <summary>
    /// Exibe uma mensagem de erro ao usuário.
    /// </summary>
    /// <param name="mensagem">Texto da mensagem a ser exibida.</param>
    public static void MostrarErro(string mensagem)
        => MessageBox.Show(mensagem, 
                                "Erro", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Error);

    /// <summary>
    /// Exibe uma mensagem de sucesso ao usuário.
    /// </summary>
    /// <param name="mensagem">Texto da mensagem a ser exibida.</param>
    public static void MostrarSucesso(string mensagem)
        => MessageBox.Show(mensagem, 
                                "Sucesso", 
                                MessageBoxButtons.OK, 
                                MessageBoxIcon.Information);

    /// <summary>
    /// Exibe uma caixa de diálogo de confirmação (Sim/Não).
    /// </summary>
    /// <param name="mensagem">Texto da mensagem a ser exibida.</param>
    /// <returns>True se o usuário confirmar (Sim), False caso contrário.</returns>
    public static bool MostrarConfirmacao(string mensagem)
    {
        DialogResult result = MessageBox.Show(
            mensagem,
            ObterTituloApp(),
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        return result == DialogResult.Yes;
    }

    /// <summary>
    /// Executa uma ação fornecida, exibindo mensagem de erro caso ocorra exceção.
    /// </summary>
    /// <param name="action">Ação a ser executada.</param>
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
