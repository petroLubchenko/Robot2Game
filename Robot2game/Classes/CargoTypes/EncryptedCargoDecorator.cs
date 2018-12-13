using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.CargoTypes
{
    public class EncryptedCargoDecorator : CargoDecorator
    {
        public EncryptedCargoDecorator(Cargo cargo): base(cargo)
        { }

        public override void Collect(Robot robot)
        {
            Console.WriteLine("This cargo is encrypted");
            if (robot.Encrypt())
                cargo.Collect(robot);
            else
                Console.WriteLine("Ooops! You make a mistake. Cargo was not decrypted");
        }
    }
}
