using Robot2game.Classes.RobotTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.Factories
{
    class WorkerRobotFactory : RobotFactory
    {
        internal override Robot Generate(String name)
        {
            return new WorkerRobot(name);
        }
    }
}
