using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.CargoTypes
{
    class ToxicCargo : Cargo
    {
        public ToxicCargo() : base()
        { }

        public override void Collect(Robot robot)
        {
            Random r = new Random();

            robot.TakeDamage(r.Next(1, 40));

            Console.WriteLine("Collected toxic cargo");
            robot.Collect(this);
        }

    }
}
