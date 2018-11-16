using Robot2game.Classes.RobotTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.Factories
{
    class ScienceRobotFactory : RobotFactory
    {
        internal override Robot Generate(string name)
        {
            return new ScienceRobot(name);
        }
    }
}
