using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.CargoTypes
{
    class StandartCargoDecorator : CargoDecorator
    {
        public StandartCargoDecorator(Cargo cargo) : base(cargo)
        {
        }

        public override void Collect(Robot robot)
        {
            cargo.Collect(robot);
        }
    }
}
