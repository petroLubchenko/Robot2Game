using Robot2game.Classes.CargoTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.Factories
{
    class CargoFactory : Factory<CargoDecorator>
    {
        public override CargoDecorator Create()
        {
            Random r = new Random();

            int cargo = r.Next(0, 2);

            Cargo c = cargo == 0 ? new StandartCargo() : cargo == 1 ? (Cargo)(new PerishableCargo()) : new ToxicCargo();

            return r.Next(0, 100) < 19 ? (CargoDecorator)(new EncryptedCargoDecorator(c)) : new StandartCargoDecorator(c);
        }
    }
}
