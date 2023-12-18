using DesafioFundamentos.Models;
using System;
using System.Diagnostics;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        decimal precoInicial = ObterDecimalInput("Seja bem vindo ao sistema de estacionamento!\nDigite o preço inicial:");
        decimal precoPorHora = ObterDecimalInput("Agora digite o preço por hora:");

        Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

        string opcao = string.Empty;
        bool exibirMenu = true;

        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    es.AdicionarVeiculo();
                    Console.WriteLine("Veículo cadastrado com sucesso!");
                    break;

                case "2":
                    es.RemoverVeiculo();
                    break;

                case "3":
                    es.ListarVeiculos();
                    break;

                case "4":
                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }

            if (exibirMenu)
            {
                Console.WriteLine("Pressione uma tecla para continuar");
                Console.ReadLine();
            }
        }

        Console.WriteLine("O programa se encerrou. Pressione uma tecla para sair.");
        Console.ReadLine();
    }

    static decimal ObterDecimalInput(string mensagem)
    {
        decimal valor = 0;
        bool entradaValida = false;

        while (!entradaValida)
        {
            Console.WriteLine(mensagem);

            if (decimal.TryParse(Console.ReadLine(), out valor))
            {
                entradaValida = true;
            }
            else
            {
                Console.WriteLine("Por favor, insira um valor numérico válido.");
            }
        }

        return valor;
    }

    private string GetDebuggerDisplay()
    {
        return ToString();
    }
}
