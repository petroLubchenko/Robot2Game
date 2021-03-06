﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.GameCommands
{
    public class MoveCommand : Command
    {
        public MoveCommand(Robot robot) : base(robot)
        {
        }

        public override void Execute()
        {
            robot.Move();

            history.Push(robot.Saveturn());
        }

        public override void Undo()
        {
            /*try
            {*/
                robot.Undo(history.Pop());
            /*}
            catch(InvalidOperationException)
            { }*/
        }
        public override string ToString()
        {
            return "Move";
        }
    }
}
