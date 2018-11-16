using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.CargoTypes
{
    class StandartCargo : Cargo
    {
        public StandartCargo() : base()
        { }
        public override void Collect(Robot robot)
        {
            Console.WriteLine("Collected standart cargo");
            robot.Collect(this);
        }
    }
}
