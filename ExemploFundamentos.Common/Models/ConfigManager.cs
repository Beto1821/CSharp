using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ExemploFundamentos.Common.Models
{
    /// <summary>
    /// Classe para gerenciar configurações da aplicação através do arquivo config.json
    /// </summary>
    public class ConfigManager
    {
        private static ConfigManager? _instance;
        private static readonly object _lock = new object();
        
        public AppSettings AppSettings { get; set; } = new();
        public CalculadoraConfig Calculadora { get; set; } = new();
        public PessoaConfig Pessoa { get; set; } = new();
        public DatabaseConfig Database { get; set; } = new();
        public LoggingConfig Logging { get; set; } = new();
        public FeaturesConfig Features { get; set; } = new();

        private ConfigManager() { }

        /// <summary>
        /// Singleton pattern para garantir uma única instância das configurações
        /// </summary>
        public static ConfigManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new ConfigManager();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Carrega as configurações do arquivo config.json
        /// </summary>
        /// <param name="configPath">Caminho para o arquivo de configuração (padrão: config.json)</param>
        public void LoadConfig(string configPath = "config.json")
        {
            try
            {
                if (!File.Exists(configPath))
                {
                    Console.WriteLine($"Arquivo de configuração não encontrado: {configPath}");
                    Console.WriteLine("Usando configurações padrão.");
                    return;
                }

                string jsonContent = File.ReadAllText(configPath);
                
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                };

                // Deserializa como um JsonDocument primeiro para acessar as propriedades
                using JsonDocument doc = JsonDocument.Parse(jsonContent);
                var root = doc.RootElement;

                // Carrega cada seção individualmente
                if (root.TryGetProperty("AppSettings", out var appSettingsElement))
                {
                    AppSettings = JsonSerializer.Deserialize<AppSettings>(appSettingsElement.GetRawText(), options) ?? new AppSettings();
                }

                if (root.TryGetProperty("Calculadora", out var calculadoraElement))
                {
                    Calculadora = JsonSerializer.Deserialize<CalculadoraConfig>(calculadoraElement.GetRawText(), options) ?? new CalculadoraConfig();
                }

                if (root.TryGetProperty("Pessoa", out var pessoaElement))
                {
                    Pessoa = JsonSerializer.Deserialize<PessoaConfig>(pessoaElement.GetRawText(), options) ?? new PessoaConfig();
                }

                if (root.TryGetProperty("Database", out var databaseElement))
                {
                    Database = JsonSerializer.Deserialize<DatabaseConfig>(databaseElement.GetRawText(), options) ?? new DatabaseConfig();
                }

                if (root.TryGetProperty("Logging", out var loggingElement))
                {
                    Logging = JsonSerializer.Deserialize<LoggingConfig>(loggingElement.GetRawText(), options) ?? new LoggingConfig();
                }

                if (root.TryGetProperty("Features", out var featuresElement))
                {
                    Features = JsonSerializer.Deserialize<FeaturesConfig>(featuresElement.GetRawText(), options) ?? new FeaturesConfig();
                }

                Console.WriteLine("Configurações carregadas com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar configurações: {ex.Message}");
                Console.WriteLine("Usando configurações padrão.");
            }
        }

        /// <summary>
        /// Salva as configurações atuais no arquivo config.json
        /// </summary>
        /// <param name="configPath">Caminho para salvar o arquivo (padrão: config.json)</param>
        public void SaveConfig(string configPath = "config.json")
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                string jsonContent = JsonSerializer.Serialize(this, options);
                File.WriteAllText(configPath, jsonContent);
                
                Console.WriteLine($"Configurações salvas em: {configPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar configurações: {ex.Message}");
            }
        }
    }

    // Classes para representar as seções de configuração
    public class AppSettings
    {
        public string ApplicationName { get; set; } = "Exemplo Fundamentos";
        public string Version { get; set; } = "1.0.0";
        public string Environment { get; set; } = "Development";
        public string LogLevel { get; set; } = "Information";
    }

    public class CalculadoraConfig
    {
        public int PrecisaoDecimal { get; set; } = 4;
        public int HistoricoMaximo { get; set; } = 10;
        public string UnidadeAngulo { get; set; } = "Graus";
        public bool PermitirDivisaoPorZero { get; set; } = false;
        public bool PermitirRaizNegativa { get; set; } = false;
    }

    public class PessoaConfig
    {
        public int IdadeMinima { get; set; } = 0;
        public int IdadeMaxima { get; set; } = 150;
        public bool NomeVazioPermitido { get; set; } = false;
    }

    public class DatabaseConfig
    {
        public string ConnectionString { get; set; } = "Server=localhost;Database=ExemploFundamentos;Trusted_Connection=true;";
        public int CommandTimeout { get; set; } = 30;
        public bool EnableRetryOnFailure { get; set; } = true;
    }

    public class LoggingConfig
    {
        public ConsoleLogging Console { get; set; } = new();
        public FileLogging File { get; set; } = new();
    }

    public class ConsoleLogging
    {
        public bool Enabled { get; set; } = true;
        public string MinLevel { get; set; } = "Information";
    }

    public class FileLogging
    {
        public bool Enabled { get; set; } = false;
        public string FilePath { get; set; } = "logs/app.log";
        public string MaxFileSize { get; set; } = "10MB";
    }

    public class FeaturesConfig
    {
        public bool CalculadoraCientifica { get; set; } = true;
        public bool HistoricoOperacoes { get; set; } = true;
        public bool ExportarResultados { get; set; } = false;
        public bool ModoDebug { get; set; } = true;
    }
}