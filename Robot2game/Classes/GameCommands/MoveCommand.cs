using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.GameCommands
{
    class MoveCommand : Command
    {
        public MoveCommand(Robot robot) : base(robot)
        {
        }

        public override void Execute()
        {
            robot.Move();

            robot.Saveturn();
        }

        public override void Undo()
        {
            robot.Undo(history.Pop());
        }
    }
}
