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
            while (true)
            {
                Console.Write("Ibput player name: ");
                new Player(Console.ReadLine()).StartGame();

                Console.ReadKey();
            }
        }
    }
}
