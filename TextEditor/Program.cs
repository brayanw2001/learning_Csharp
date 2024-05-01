using System;
using System.Threading;
using System.IO;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("1. Abrir arquivo. \n2. Criar novo arquivo. \n0. Sair");
            Console.Write("Insira a opção: ");
            short option = short.Parse(Console.ReadLine());

            switch (option)
            {
                case 0: 
                    System.Environment.Exit(0);
                    break;
                case 1: 
                    AbrirArquivo();
                    break;
                case 2: 
                    EditarArquivo();   
                    break;
                default:
                    Menu();
                    break;
            }
        }

        static void AbrirArquivo() 
        {

        }

        static void EditarArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair)");
            Console.WriteLine("_______________________");
            string text = "";       //string para armazenar a entrada do usuário

            do 
            {
                text += Console.ReadLine(); //text += contatena em text
                text += Environment.NewLine; //colocando uma quebra de linha
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            SalvarArquivo(text);
        }   

        static void SalvarArquivo (string text)
        {
            Console.Clear();
            Console.WriteLine("Qual o diretório para salvar o arquivo?");
            string path = Console.ReadLine();

            
            using(var file = new StreamWriter(path))         //abre o objeto e fecha automatico
            {
                file.Write(text);   
            }
            Console.WriteLine($"Arquivo salvo com sucesso em {path}!");
            Menu();
        }
    }
}

//block005 13:19