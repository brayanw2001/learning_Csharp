namespace TheColor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Color customColor = new Color(127, 255, 0);
            Color orange = Color.Orange();

            Console.WriteLine($"({customColor.R}, {customColor.G}, {customColor.B})");
            Console.WriteLine($"({orange.R}, {orange.G}, {orange.B})");
        }
    }
}
