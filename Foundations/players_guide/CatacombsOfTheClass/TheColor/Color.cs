namespace TheColor;

class Color
{
    public int r { get; }
    public int g { get; }
    public int b { get; }

    public struct White
    {
        public static  readonly int r = 255;
        public static readonly int g = 255;
        public static readonly int b = 255;
    }

    public struct Black
    {
        public static readonly int r = 0;
        public static readonly int g = 0;
        public static readonly int b = 0;
    }

    public struct Red 
    {
        public static readonly int r = 255;
        public static readonly int g = 0;
        public static readonly int b = 0;
    }

    public Color(int r, int g, int b)
    {
        this.r = r;
        this.g = g;
        this.b = b;
    }
}
