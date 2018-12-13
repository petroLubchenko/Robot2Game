using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.CargoTypes
{
    public class PerishableCargo : Cargo
    {
        public PerishableCargo() : base()
        {
            Random r = new Random();
            shelflife = (short)r.Next(3, 8);
        }

        public override void Collect(Robot robot)
        {
            Console.WriteLine("Colleced perishable cargo. It will be removed in " + shelflife + " turns");
            robot.Collect(this);
        }

    }
}
