namespace IncidentesAI.Helpers;

public class ConfigHelper
{
    private readonly string _filePath;
    private Dictionary<string, string> _configValues;

    public ConfigHelper(string filePath)
    {
        _filePath = filePath;
        _configValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        Load();
    }

    /// <summary>
    /// Lê o arquivo config.dat e carrega os valores em memória
    /// </summary>
    private void Load()
    {
        if (!File.Exists(_filePath))
            throw new FileNotFoundException("Arquivo de configuração não encontrado.", _filePath);

        _configValues.Clear();
        foreach (var line in File.ReadAllLines(_filePath))
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            var parts = line.Split(new[] { ':' }, 2);
            if (parts.Length == 2)
            {
                _configValues[parts[0].Trim()] = parts[1].Trim();
            }
        }
    }

    /// <summary>
    /// Obtém o valor de uma chave
    /// </summary>
    public string GetValue(string key)
    {
        return _configValues.ContainsKey(key) ? _configValues[key] : null;
    }

    /// <summary>
    /// Atualiza ou adiciona uma chave/valor
    /// </summary>
    public void SetValue(string key, string value)
    {
        _configValues[key] = value;
        Save();
    }

    /// <summary>
    /// Salva os valores atuais de volta no arquivo
    /// </summary>
    private void Save()
    {
        using (var writer = new StreamWriter(_filePath))
        {
            foreach (var kvp in _configValues)
            {
                writer.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }
}
