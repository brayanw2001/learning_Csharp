using System;


namespace EditorHtml
{
    public static class Menu
    {
        public static void Show ()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            DrawScreen();
            WriteOptions();
            short opc = short.Parse(Console.ReadLine());
            HandleMenuOption(opc);
        }

        public static void DrawScreen()
        {
            Console.Write("-+");

            for (int head = 0; head < 30; head ++)
                Console.Write("-");

            Console.WriteLine("+-");

            for (int linhas = 0; linhas < 10; linhas ++)
            {
                Console.Write(" |");
                for (int space = 0; space < 30; space++)
                    Console.Write(" ");
                Console.Write("| ");
                Console.Write("\n");
            }

            Console.Write("-+");

            for (int head = 0; head < 30; head ++)
                Console.Write("-");

            Console.WriteLine("+-");
        }

        public static void WriteOptions()
        {
            Console.SetCursorPosition(3,2);
            Console.WriteLine("        Editor HTML\n");
            Console.SetCursorPosition(3,3);
            Console.WriteLine("1. Novo Arquivo");
            Console.SetCursorPosition(3,4);
            Console.WriteLine("2. Editar Arquivo");
            Console.SetCursorPosition(3,5);
            Console.WriteLine("0. Sair");
            Console.SetCursorPosition(3,7);

            string prompt = "Selecione a opção: ";
            Console.Write(prompt);
            Console.SetCursorPosition(prompt.Length+3, 7);        
            // short opc = short.Parse(Console.ReadLine());
        }

        public static void HandleMenuOption(short opc)
        {
            switch (opc)
            {
                case 1: 
                    Editor.Show();
                    break;
                case 2:
                    Console.WriteLine ("Visualizar");
                    break;
                case 0:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default: 
                    Show();
                    break;
            }
        }
    } 
}