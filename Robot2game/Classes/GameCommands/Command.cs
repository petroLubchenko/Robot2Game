using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.GameCommands
{
    public abstract class Command
    {
        protected Robot robot;
        protected RobotHistory history = new RobotHistory();

        public Command(Robot robot)
        {
            this.robot = robot;
        }

        public abstract void Execute();
        public abstract void Undo();
    }
}
