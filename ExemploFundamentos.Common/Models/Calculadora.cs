using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploFundamentos.Common.Models
{
    /// <summary>
    /// Classe Calculadora - Exemplo didático para demonstrar operações matemáticas básicas
    /// </summary>
    public class Calculadora
    {
        /// <summary>
        /// Realiza a operação de soma entre dois números
        /// </summary>
        /// <param name="a">Primeiro número</param>
        /// <param name="b">Segundo número</param>
        /// <returns>Resultado da soma</returns>
        public double Somar(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Realiza a operação de subtração entre dois números
        /// </summary>
        /// <param name="a">Primeiro número (minuendo)</param>
        /// <param name="b">Segundo número (subtraendo)</param>
        /// <returns>Resultado da subtração</returns>
        public double Subtrair(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Realiza a operação de multiplicação entre dois números
        /// </summary>
        /// <param name="a">Primeiro número</param>
        /// <param name="b">Segundo número</param>
        /// <returns>Resultado da multiplicação</returns>
        public double Multiplicar(double a, double b)
        {
            return a * b;
        }

        /// <summary>
        /// Realiza a operação de divisão entre dois números
        /// </summary>
        /// <param name="a">Dividendo</param>
        /// <param name="b">Divisor</param>
        /// <returns>Resultado da divisão</returns>
        /// <exception cref="DivideByZeroException">Lançada quando o divisor é zero</exception>
        public double Dividir(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Não é possível dividir por zero!");
            }
            return a / b;
        }

        /// <summary>
        /// Calcula a potência de um número
        /// </summary>
        /// <param name="baseNum">Número base</param>
        /// <param name="expoente">Expoente</param>
        /// <returns>Resultado da potenciação</returns>
        public double Potencia(double baseNum, double expoente)
        {
            return Math.Pow(baseNum, expoente);
        }

        /// <summary>
        /// Calcula a raiz quadrada de um número
        /// </summary>
        /// <param name="numero">Número para calcular a raiz quadrada</param>
        /// <returns>Resultado da raiz quadrada</returns>
        /// <exception cref="ArgumentException">Lançada quando o número é negativo</exception>
        public double RaizQuadrada(double numero)
        {
            if (numero < 0)
            {
                throw new ArgumentException("Não é possível calcular raiz quadrada de número negativo!");
            }
            return Math.Sqrt(numero);
        }

        /// <summary>
        /// Calcula o seno de um ângulo em graus
        /// </summary>
        /// <param name="angulo">Ângulo em graus</param>
        /// <returns>Seno do ângulo</returns>
        public double Seno(double angulo)
        {
            double radianos = angulo * Math.PI / 180;
            return Math.Sin(radianos);
        }

        /// <summary>
        /// Calcula o cosseno de um ângulo em graus
        /// </summary>
        /// <param name="angulo">Ângulo em graus</param>
        /// <returns>Cosseno do ângulo</returns>
        public double Cosseno(double angulo)
        {
            double radianos = angulo * Math.PI / 180;
            return Math.Cos(radianos);
        }

        /// <summary>
        /// Calcula a tangente de um ângulo em graus
        /// </summary>
        /// <param name="angulo">Ângulo em graus</param>
        /// <returns>Tangente do ângulo</returns>
        public double Tangente(double angulo)
        {
            double radianos = angulo * Math.PI / 180;
            return Math.Tan(radianos);
        }

        /// <summary>
        /// Apresenta o histórico das últimas operações realizadas
        /// </summary>
        /// <param name="historico">Lista com o histórico das operações</param>
        public void ApresentarHistorico(List<string> historico)
        {
            Console.WriteLine("=== HISTÓRICO DE OPERAÇÕES ===");
            if (historico.Count == 0)
            {
                Console.WriteLine("Nenhuma operação realizada ainda.");
                return;
            }

            for (int i = 0; i < historico.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {historico[i]}");
            }
            Console.WriteLine("===============================");
        }
    }
}