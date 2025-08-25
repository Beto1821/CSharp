using ExDOTNET.Models;

class Program
{
    static void Main(string[] args)
    {
        Pessoa p = new Pessoa();
        p.Nome = "Adalberto";
        p.Idade = 50;
        p.Apresentar();
    }
}