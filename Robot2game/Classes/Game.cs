using Robot2game.Classes.Factories;
using Robot2game.Classes.GameCommands;
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
        private Command[] commands;
        private int turn = 0;

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

            commands = { new MoveCommand(robot); };
        }

        public string StartGame()
        {
            Console.WriteLine(String.Format("\nStart of the game\nYour robot - {0}\n{1}\nPress any key to start the game", robot.Type, robot.Legend));
            Console.ReadKey();
            bool gameended = false;
            GameController gcon = new GameController(robot);

            // Game cycle
            do
            {
                // TODO Use command pattern
                // Checking a command
                var comm = commands[turn % 2];
                gcon.SetCommand(comm);


                

                turn++;
                ShowInfo();
            }
            while (true);


            return String.Format("\n\n{0} , {1} , {2}", player.Nickname, robot.RobotInformation, "");
        }


        private void ShowInfo()
        {
            Console.WriteLine(robot.RobotInformation);
        }
    }
}
