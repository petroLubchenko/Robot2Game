using Robot2game.Classes.Factories;
using Robot2game.Classes.RobotTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    class Game
    {
        private Player player;
        private Robot robot;

        private float nofreightchance = 0.2F; // Chanse of non-freight stop

        Random rand = new Random();

        public Game(Player player)
        {
            this.player = player;

            // TODO use abstract factory!!!
            Random r = new Random();
            int num = r.Next(0, 100);
            if (num < 50)
                robot = new WorkerRobot(player.Nickname);
            else
                if (num < 80)
                    robot = new CyborgRobot(player.Nickname);
                else
                    robot = new ScienceRobot(player.Nickname);
        }

        public string StartGame()
        {
            Console.WriteLine(String.Format("\nStart of the game\nYour robot - {0}\n{1}\nPress any key to start the game", robot.Type, robot.Legend));
            Console.ReadKey();

            // Game cycle
            do
            {
                // TODO Use command pattern
                bool gameended = false;
                do
                {
                    gameended = robot.CheckEnergy();
                    if (gameended)
                    {
                        break;
                    }
                    robot.Move();

                }
                while (rand.Next(0, 100) < nofreightchance * 100);

                if (gameended)
                    break;

                Cargo[] cargoes = new Cargo[3];

                cargoes = GenerateCargoes(3);

                ShowUI(cargoes);

                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1)
                    cargoes[0].Collect(robot);

                ShowInfo();
            }
            while (true);


            return String.Format("\n\n{0} , {1} , {2}", player.Nickname, robot.RobotInformation, "");
        }


        private void ShowInfo()
        {
            Console.WriteLine(robot.RobotInformation);
        }
        private Cargo[] GenerateCargoes(int count)
        {
            Cargo[] cs = new Cargo[count];
            CargoFactory cf = new CargoFactory();

            for (int i = 0; i < count; i++)
                cs[i] = cf.Create();

            return cs;
        }
        private void ShowUI(Cargo[] cargoes)
        {
            Console.WriteLine(String.Format("Button\tResult\n1-3   \tCollect cargo\n4     \texit"));
        }
    }
}
