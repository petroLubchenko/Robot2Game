using Robot2game.Classes.RobotTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.Factories
{
    class CyborgRobotFactory : RobotFactory
    {
        internal override Robot Generate(string name)
        {
            return new CyborgRobot(name);
        }
    }
}
