using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboto.Classes.RobotTypes
{
    class ScienceRobot : Robot
    {
        private static string sciencelegend = "This is science robot...";

        public ScienceRobot(string name) : base(name)
        {
            legend = sciencelegend;

            batterycoef = 1.1F;
            loadcoef = 0.9F;
        }
    }
}
