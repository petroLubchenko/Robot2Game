﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    class RobotMemento
    {
        public float Energy { get; private set; }
        public ushort Load { get; private set; }
        public int Cost { get; private set; }

        public RobotMemento(float energy, ushort load, int cost)
        {
            Energy = energy;
            Load = load;
            Cost = cost;
        }
    }
}