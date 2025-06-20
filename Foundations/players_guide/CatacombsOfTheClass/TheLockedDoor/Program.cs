namespace The_Locked_Door
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Door door = new Door();

            while (true)
            {
                Console.WriteLine($"Door is {door.state}");
                Console.WriteLine("[1] Open | [2] Close | [3] Lock | [4] Unlock | [0] Trocar senha");

                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        door.ChangePassword();
                        break;
                    case 1:
                        door.ToOpen();
                        break;
                    case 2:
                        door.ToClose();
                        break;
                    case 3:
                        door.ToLock();
                        break;
                    case 4:
                        door.ToUnlock();
                        break;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }
    }
}
