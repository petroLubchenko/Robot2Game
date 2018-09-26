using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboto.Classes.RobotTypes
{
    class WorkerRobot : Robot
    {
        static string workerlegend = "This is worker...";
        public WorkerRobot(string name) : base(name)
        {
            legend = workerlegend;

            batterycoef = 1.3F;
            loadcoef = 1.8F;
        }


    }
}
