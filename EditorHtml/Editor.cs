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
            ChecksAnswer(file.ToString());
        }

        public static void ChecksAnswer(string file)
        {
            var answer = Console.ReadLine();

            if (answer.StartsWith('y'))
            {
                Console.Clear();
                SaveFile(file);
            } 
            else if (answer.StartsWith('n'))
            {
                Console.Clear();
                Console.Write("não");
            } 
            else 
            {
                Console.Clear();
                Console.WriteLine("Opção inválida. Tente novamente!");
                Thread.Sleep(800);
                Console.WriteLine("Deseja salvar o arquivo? [y/n]");
                SaveFile(file);
            }
        }    

        public static void SaveFile (string file) 
        {
                Console.Clear();
                Console.WriteLine("Em qual diretório deseja salvar o arquivo?");
                string path = Console.ReadLine();

                using (var SavedFile = new StreamWriter(path))  // using <- abre e fecha o arquivo savedFile
                {
                    SavedFile.Write(file);                      // o arquivo criado receberá o conteúdo de file
                }
                Console.WriteLine($"Arquivo salvo com sucesso em {path}!");
        }    
    }
}