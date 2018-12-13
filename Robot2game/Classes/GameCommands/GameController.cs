using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.GameCommands
{
    public class GameController
    {
        private Robot robot;
        private Command command;

        public Command Command
        {
            get
            {
                return command;
            }
        }

        public GameController(Robot robot)
        {
            this.robot = robot;
        }
        public GameController(Robot robot, Command command)
        {
            this.robot = robot;
            this.command = command;
        }

        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void Execute()
        {
            command.Execute();
        }

        public void Undo()
        {
            command.Undo();
        }
    }
}
