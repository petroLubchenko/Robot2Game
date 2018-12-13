using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.RobotTypes
{
    public class CyborgRobot : Robot
    {
        public  static string cyborglegend = "This is cyborg...";
        public CyborgRobot(string name) : base(name)
        {
            legend = cyborglegend;

            batterycoef = 1.3F;
            loadcoef = 1.2F;
            decodechance = 60;
            type = "Cyborg";

            energy = MaxBattery;
        }

    }
}
