using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.Factories
{
    public abstract class RobotFactory
    {
        internal abstract Robot Generate(String name);
    }
}
