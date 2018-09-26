using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    class RobotHistory
    {
        private Stack<RobotMemento> history;
        public RobotHistory()
        {
            history = new Stack<RobotMemento>();
        }

        public void Push(RobotMemento rm)
        {
            history.Push(rm);
        }
        public RobotMemento Pop()
        {
            return history.Pop();
        }
    }
}
