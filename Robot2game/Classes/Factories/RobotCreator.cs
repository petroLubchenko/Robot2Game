using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.Factories
{
    public class RobotCreator
    {
        public Robot Create(String name)
        {
            Random r = new Random();
            byte key = (byte)r.Next(0, 100);
            if (key < 50)
                return (new WorkerRobotFactory()).Generate(name);
            if (key < 80)
                return (new CyborgRobotFactory()).Generate(name);
            return (new ScienceRobotFactory()).Generate(name);
        }

    }
}
