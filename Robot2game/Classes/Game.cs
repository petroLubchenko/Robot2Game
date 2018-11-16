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

            
            robot = (new RobotCreator()).Create(player.Nickname);
            Console.WriteLine("Your robot type is " + robot.Type);
            commands = new Command[]{ new MoveCommand(robot), new GenCollectCommand(robot) };
        }

        public string StartGame()
        {
            turn++;
            Console.WriteLine(String.Format("\nStart of the game\nYour robot - {0}\n{1}\nPress any key to start the game", robot.Type, robot.Legend));
            Console.ReadKey();
            bool gameended = false;
            GameController gcon = new GameController(robot);

            // Game cycle
            do
            {
                
                // Checking a command
                var comm = commands[turn % 2];
                gcon.SetCommand(comm);

                Console.WriteLine(String.Format("\nTurn {0}. Next operation - {1}. \nClick arrow right or 1 to continue or \narrow left or 2 to undo last move" +
                                                "\nbutton i to show information", (int)(turn / 2), comm.ToString()));

                ConsoleKeyInfo cki = new ConsoleKeyInfo();
                cki = Console.ReadKey();

                if (cki.Key == ConsoleKey.RightArrow || cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1)
                    gcon.Execute();
                else
                    if (cki.Key == ConsoleKey.LeftArrow || cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2)
                {
                    if (turn != 1)
                        gcon.SetCommand(commands[(--turn) % 2]);
                    continue;
                }
                else 
                    if(cki.Key == ConsoleKey.I)
                {
                    ShowInfo();
                    continue;
                }
                else
                    continue;

                if (robot.CheckEnergy())
                    gameended = true;

                turn++;
                if (turn % 2 == 0)
                    ShowInfo();
            }
            while (!gameended);


            return String.Format("\n\n{0} , {1} , {2}", player.Nickname, robot.RobotInformation, "");
        }


        private void ShowInfo()
        {
            Console.WriteLine("\n" + robot.RobotInformation);
        }
    }
}
