using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboto.Classes.RobotTypes
{
    class CyborgRobot : Robot
    {
        static string cyborglegend = "This is cyborg...";
        public CyborgRobot(string name) : base(name)
        {
            legend = cyborglegend;

            batterycoef = 1.3F;
            loadcoef = 1.2F;
        }

    }
}
