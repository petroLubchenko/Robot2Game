using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.CargoTypes
{
    class PerishableCargo : Cargo
    {
        public PerishableCargo() : base()
        {
            Random r = new Random();
            shelflife = (short)r.Next(3, 20);
        }

        public override void Collect(Robot robot)
        {
            robot.Collect(this);
        }

    }
}
