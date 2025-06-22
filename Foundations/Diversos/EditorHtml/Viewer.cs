using System;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;

namespace EditorHtml
{
    public class Viewer
    {
        public static void Show (string text)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.WriteLine("MODO DE VISUALIZAÇÃO");
            Replace(text);
            Console.ReadKey();
            Menu.Show();
        }

        public static void Replace (string text)
        {
            var strong = new Regex(@"<\s*strong[^>]*>(.*?)<\s*/\s*strong>");
            var words = text.Split(' ');

            for (var i = 0; i < words.Length; i++)
            {
                if (strong.IsMatch(words[i]))           // se a string filtrada por regex == a palavra na posição [i] separada pelo split
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(
                        words[i].Substring(                 // substring(n, x) <- retorna o texto de 'x' caracteres depois da posição 'n'
                            words[i].IndexOf('>') + 1,       
                            (
                                (words[i].LastIndexOf('<') - 1) -           
                                words[i].IndexOf('>')
                            )
                        )
                    );

                    Console.Write(" ");
                } else {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(words[i]);
                    Console.Write(" ");
                }
            }
        }

    }
}
