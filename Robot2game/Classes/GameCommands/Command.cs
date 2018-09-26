using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.GameCommands
{
    abstract class Command
    {
        private Robot robot;

        public Command(Robot robot)
        {
            this.robot = robot;
        }

        public abstract void Execute();
    }
}
