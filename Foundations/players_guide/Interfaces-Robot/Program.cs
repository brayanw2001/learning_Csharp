namespace Interfaces_Robot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new();
            //string [] commands = new string [3];

            for (int i = 0; i < 3; i++)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();

                IRobotCommand newCommand = input switch
                {
                    "on" => new OnCommand(),
                    "off" => new OffCommand(),
                    "north" => new NorthCommand(),
                    "south" => new SouthCommand(),
                    "east" => new EastCommand(),
                    "west" => new WestCommand(),
                };

                robot.Commands[i] = newCommand;
            }
                robot.Run();

                Console.WriteLine($"[Status: {robot.IsPowered} | X = {robot.X} | Y = {robot.Y}]");
                // trocar esse CW por um ToString na classe Robot
        }
    }
}
