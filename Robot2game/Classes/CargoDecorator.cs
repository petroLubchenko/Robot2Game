using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    public abstract class CargoDecorator : Cargo
    {
        protected Cargo cargo;
        public Cargo Cargo
        {
            get
            {
                return cargo;
            }
        }
        public CargoDecorator(Cargo cargo) : base()
        {
            this.cargo = cargo;
        }
    }
}
