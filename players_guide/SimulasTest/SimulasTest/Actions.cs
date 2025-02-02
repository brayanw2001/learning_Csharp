using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulasTest
{
    internal class Actions
    {
        States state = States.locked;
        public Actions()
        {
            while (true)
            {
                string text = $"The chest is {state}. What do you want to do? ";
                string? answer = States.locked.ToString();

                switch (state)
                {
                    case States.locked:

                        Console.WriteLine(text);
                        answer = Console.ReadLine();

                        if (answer == "unlock")
                            toUnlock();
                        else
                            Console.WriteLine("Tente novamente");
                        break;

                    case States.closed:

                        Console.WriteLine(text);
                        answer = Console.ReadLine();

                        if (answer == "open")
                            toOpen();
                        else if (answer == "lock")
                            toLock();
                        else
                            Console.WriteLine("Tente novamente");
                        break;

                    case States.open:

                        Console.WriteLine(text);
                        answer = Console.ReadLine();

                        if (answer == "close")
                            toClose();
                        else
                            Console.WriteLine("Tente novamente");
                        break;
                }
            }
        }

        internal States toClose() => state = States.closed;
        internal States toLock() => state = States.locked;
        internal States toUnlock() => state = States.closed;
        internal States toOpen() => state = States.open;
    }
}
