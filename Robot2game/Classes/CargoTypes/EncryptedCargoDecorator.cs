using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.CargoTypes
{
    class EncryptedCargoDecorator : CargoDecorator
    {
        public EncryptedCargoDecorator(Cargo cargo): base(cargo)
        { }

        public override void Collect(Robot robot)
        {
            if (robot.Encrypt())
                cargo.Collect(robot);
        }
    }
}
