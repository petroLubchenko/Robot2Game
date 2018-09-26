using Robot2game.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game
{
    class Program
    {
        static void Main(string[] args)
        {
            new Player("QWerty").StartGame();

            Console.ReadKey();
        }
    }
}
