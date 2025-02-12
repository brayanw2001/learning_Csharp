namespace TheColor;

class Program
{
    static void Main(string[] args)
    {
        Color color = new Color(125, 200, 30);
        
        System.Console.WriteLine($"{color.r}, {color.g}, {color.b} | {Color.White.r}, {Color.White.g}, {Color.White.b}");
    }
}
