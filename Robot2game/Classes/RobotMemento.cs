using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    public class RobotMemento
    {
        public float Energy { get; private set; }
        public ushort Load { get; private set; }
        public int Cost { get; private set; }
        public float batterycoef;
        public float loadcoef;
        public float consumcoef;

        public Dictionary<Cargo, int> perishables;

        public RobotMemento(float energy, ushort load, int cost, float batteryc, float loadc, float consc)
        {
            Energy = energy;
            Load = load;
            Cost = cost;
            batterycoef = batteryc;
            loadcoef = loadc;
            consumcoef = consc;
        }
    }
}
