using ExemploFundamentos.Common.Models;

Pessoa pessoa1 = new Pessoa();
pessoa1.Nome = "Adalberto";
pessoa1.Idade = 50;
pessoa1.Apresentar();




// class Program
// {
//     static void Main(string[] args)
//     {
//         // Carrega as configurações do arquivo config.json
//         ConfigManager.Instance.LoadConfig();
        
//         Console.WriteLine("=== CONFIGURAÇÕES DA APLICAÇÃO ===");
//         MostrarConfiguracoes();
        
//         Console.WriteLine("\n=== EXEMPLO COM CLASSE PESSOA ===");
//         Pessoa p = new Pessoa();
//         p.Nome = "Adalberto";
//         p.Idade = 50;
//         p.Apresentar();
        
//         Console.WriteLine("\n=== EXEMPLO COM CALCULADORA ===");
//         ExemplosCalculadora();
//     }

//     static void MostrarConfiguracoes()
//     {
//         var config = ConfigManager.Instance;
        
//         Console.WriteLine($"Aplicação: {config.AppSettings.ApplicationName}");
//         Console.WriteLine($"Versão: {config.AppSettings.Version}");
//         Console.WriteLine($"Ambiente: {config.AppSettings.Environment}");
//         Console.WriteLine($"Precisão Decimal: {config.Calculadora.PrecisaoDecimal}");
//         Console.WriteLine($"Histórico Máximo: {config.Calculadora.HistoricoMaximo}");
//         Console.WriteLine($"Modo Debug: {(config.Features.ModoDebug ? "Ativo" : "Inativo")}");
//         Console.WriteLine($"Calculadora Científica: {(config.Features.CalculadoraCientifica ? "Habilitada" : "Desabilitada")}");
//     }

//     static void ExemplosCalculadora()
//     {
//         Calculadora calc = new Calculadora();
//         List<string> historico = new List<string>();
//         var config = ConfigManager.Instance;

//         try
//         {
//             // Operações básicas com precisão configurável
//             double soma = calc.Somar(10, 5);
//             Console.WriteLine($"10 + 5 = {soma.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//             historico.Add($"10 + 5 = {soma.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");

//             double subtracao = calc.Subtrair(10, 3);
//             Console.WriteLine($"10 - 3 = {subtracao.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//             historico.Add($"10 - 3 = {subtracao.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");

//             double multiplicacao = calc.Multiplicar(4, 7);
//             Console.WriteLine($"4 × 7 = {multiplicacao.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//             historico.Add($"4 × 7 = {multiplicacao.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");

//             double divisao = calc.Dividir(15, 3);
//             Console.WriteLine($"15 ÷ 3 = {divisao.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//             historico.Add($"15 ÷ 3 = {divisao.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");

//             // Só executa operações científicas se estiver habilitado na config
//             if (config.Features.CalculadoraCientifica)
//             {
//                 Console.WriteLine("\n--- Operações Científicas ---");
                
//                 double potencia = calc.Potencia(2, 3);
//                 Console.WriteLine($"2³ = {potencia.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//                 historico.Add($"2³ = {potencia.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");

//                 double raiz = calc.RaizQuadrada(16);
//                 Console.WriteLine($"√16 = {raiz.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//                 historico.Add($"√16 = {raiz.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");

//                 // Funções trigonométricas
//                 double seno = calc.Seno(30); // 30 graus
//                 Console.WriteLine($"sen(30°) = {seno.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//                 historico.Add($"sen(30°) = {seno.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");

//                 double cosseno = calc.Cosseno(60); // 60 graus
//                 Console.WriteLine($"cos(60°) = {cosseno.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//                 historico.Add($"cos(60°) = {cosseno.ToString($"F{config.Calculadora.PrecisaoDecimal}")}");
//             }

//             // Só mostra histórico se estiver habilitado
//             if (config.Features.HistoricoOperacoes)
//             {
//                 Console.WriteLine();
//                 // Limita o histórico ao máximo configurado
//                 var historicoLimitado = historico.Take(config.Calculadora.HistoricoMaximo).ToList();
//                 calc.ApresentarHistorico(historicoLimitado);
//             }

//             // Exemplo de tratamento de exceção baseado na configuração
//             Console.WriteLine("\n=== EXEMPLO DE TRATAMENTO DE EXCEÇÃO ===");
            
//             if (config.Features.ModoDebug)
//             {
//                 Console.WriteLine("Modo Debug ativo - Testando exceções:");
//             }
            
//             try
//             {
//                 double divisaoPorZero = calc.Dividir(10, 0);
//             }
//             catch (DivideByZeroException ex)
//             {
//                 Console.WriteLine($"Erro: {ex.Message}");
//                 if (config.Features.ModoDebug)
//                 {
//                     Console.WriteLine($"Debug: Divisão por zero configurada como não permitida");
//                 }
//             }

//             try
//             {
//                 double raizNegativa = calc.RaizQuadrada(-9);
//             }
//             catch (ArgumentException ex)
//             {
//                 Console.WriteLine($"Erro: {ex.Message}");
//                 if (config.Features.ModoDebug)
//                 {
//                     Console.WriteLine($"Debug: Raiz negativa configurada como não permitida");
//                 }
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Erro inesperado: {ex.Message}");
            
//             if (config.Features.ModoDebug)
//             {
//                 Console.WriteLine($"Stack Trace: {ex.StackTrace}");
//             }
//         }
//     }
// }