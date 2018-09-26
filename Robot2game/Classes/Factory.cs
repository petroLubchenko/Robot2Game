using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    abstract class Factory<T>
    {
        public Factory()
        { }

        public abstract T Create();
    }
}
