namespace ThePoint;

class Point
{
    public int x { get; }
    public int y { get; }

    public Point()
    {
        this.x = 0;
        this.y = 0;
    }
    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}
