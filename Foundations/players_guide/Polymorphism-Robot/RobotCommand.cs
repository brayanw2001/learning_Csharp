using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_Robot
{
    public abstract class RobotCommand
    {
        public abstract void Run(Robot robot);
        //public abstract void Move(Robot robot);

    }
}
