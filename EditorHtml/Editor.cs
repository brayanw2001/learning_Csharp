using System;
using System.Text;

namespace EditorHtml 
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Start();
        }
        public static void Start()
        {
            Console.WriteLine("(Aperte ESC para sair.)");
            Console.WriteLine("_______________________");

            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.WriteLine("DDeseja salvar o arquivo? [y/n]");
            SaveFile();
        }
        public static void SaveFile()
        {
            var answer = Console.ReadLine();

            if (answer.StartsWith('y'))
            {
                Console.Clear();
                Console.Write("sim");       //implementar salvamento
            } 
            else
            {
                Console.Clear();
                Console.Write("não");
            } 
        }        
    }
}