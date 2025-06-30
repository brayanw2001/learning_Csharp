namespace ThePoint;

class Program
{
    static void Main(string[] args)
    {
        Point point = new Point();
        Point[] points = new Point [2];
        points[0] = new Point(2,3);
        points[1] = new Point(-4,0);    

        System.Console.WriteLine($"Origin: {point.x}, {point.y} \nPoints[0]: {points[0].x}, {points[0].y}\nPoints[1]: {points[1].x}, {points[1].y}");
    }
}
