using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    abstract class Cargo
    {
        private const ushort defweight = 50;
        private const ushort defcost = 100;

        protected float weicoef;
        protected float costcoef;
        protected short shelflife = -1; // -1 - infinity, turns

        internal ushort Weight
        {
            get
            {
                if (weicoef != default(float))
                    return (ushort)(defweight * weicoef + 1);
                return defweight;
            }
        }
        internal ushort Cost
        {
            get
            {
                if (costcoef != default(float))
                    return (ushort)(defcost * costcoef + 1);
                return defcost;
            }
        }

        public Cargo()
        {
            Random r = new Random();
            weicoef = (r.Next(0, 100)) / r.Next(1, 100);
            costcoef = (r.Next(0, 100)) / r.Next(1, 100);
        }

        public abstract void Collect(Robot robot);
    }
}
