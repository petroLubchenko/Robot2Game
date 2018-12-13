using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    public abstract class Cargo
    {
        private const ushort defweight = 50;
        private const ushort defcost = 100;

        protected float weicoef;
        protected float costcoef;
        protected short shelflife = -1; // -1 - infinity turns

        public int Shelflife
        {
            get
            {
                return (int)shelflife;
            }
        }

        public ushort Weight
        {
            get
            {
                if (weicoef != default(float))
                    return (ushort)(defweight * weicoef + 1);
                return defweight;
            }
        }
        public ushort Cost
        {
            get
            {
                if (costcoef != default(float))
                    return (ushort)(defcost * costcoef + 1);
                return defcost;
            }
        }
        public short ShelfLife
        {
            get
            {
                return shelflife;
            }
        }

        public Cargo()
        {
            Random r = new Random();
            weicoef = (r.Next(1, 100)) / r.Next(1, 100);
            costcoef = (r.Next(1, 100)) / r.Next(1, 100);
        }

        public abstract void Collect(Robot robot);
    }
}
