using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace IncidentesAI.Services;

public class MistralService
{
    private const string ApiKey = "N9g9RvMHE970MEpzRQhsj7hqQ3jhgti2";
    private const string BaseUrl = "https://api.mistral.ai/v1/chat/completions";
    private static readonly HttpClient _httpClient = new HttpClient();

    public async Task<string> PerguntarMistralAsync(string pergunta, string contextoDados)
    {
        _httpClient.DefaultRequestHeaders.Clear();
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {ApiKey}");

        string promptSistema = "Você é um assistente de IA.\n\nDados:\n" + contextoDados;

        var payload = new
        {
            model = "mistral-small-latest",
            messages = new[]
            {
                    new { role = "system", content = promptSistema },
                    new { role = "user", content = pergunta }
                },
            temperature = 0.7
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync(BaseUrl, payload);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                using var doc = JsonDocument.Parse(responseBody);
                string respostaRaw = doc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString() ?? "";

                return respostaRaw;
            }
            else
            {
                return $"Erro na API Mistral ({response.StatusCode}): {responseBody}";
            }
        }
        catch (Exception ex)
        {
            return $"Erro de comunicação: {ex.Message}";
        }
    }
}