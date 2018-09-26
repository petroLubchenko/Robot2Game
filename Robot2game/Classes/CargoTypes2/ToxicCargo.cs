using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboto.Classes.CargoTypes
{
    class ToxicCargo : Cargo
    {
        public ToxicCargo() : base()
        { }

        public override void Collect(Robot robot)
        {
            //decrease health/energy/destroy random weight
        }

    }
}
