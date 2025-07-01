namespace Polymorphism_Robot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new();
            //string [] commands = new string [3];
            string commands;

            for (int i = 0; i < 3; i++)
            {
                Console.Write("> ");
                
                switch (Console.ReadLine())
                {
                    case "on":
                        OnCommand turnOn = new();
                        turnOn.Run(robot);
                        break;
                    case "off":
                        OffComannd turnOff = new();
                        turnOff.Run(robot);
                        break;
                    case "north":
                        NorthCommand north = new();
                        north.Run(robot);
                        break;
                    case "south":
                        SouthCommand south = new();
                        south.Run(robot);
                        break;
                    case "west":
                        WestCommand west = new();
                        west.Run(robot);
                        break;
                    case "east":
                        EastCommand east = new();
                        east.Run(robot);
                        break;
                }
            }
                Console.WriteLine($"[Status: {robot.IsPowered} | X = {robot.X} | Y = {robot.Y}]");
                // trocar esse CW por um ToString na classe Robot
        }
    }
}
