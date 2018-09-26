using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roboto.Classes.CargoTypes
{
    class EncryptedCargoDecorator : CargoDecorator
    {
        public EncryptedCargoDecorator(Cargo cargo): base(cargo)
        { }

        public override void Collect(Robot robot)
        {
            // Try to encrypt

            // cargo.collect() if decrypted or robot.collect(null)
        }
    }
}
