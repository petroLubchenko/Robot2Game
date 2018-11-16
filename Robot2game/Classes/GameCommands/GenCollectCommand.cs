using Robot2game.Classes.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes.GameCommands
{
    class GenCollectCommand : Command
    {
        public GenCollectCommand(Robot robot) : base(robot)
        {
        }

        public override void Execute()
        {
            Cargo[] cargoes = new Cargo[3];

            cargoes = GenerateCargoes(3);

            ShowUI(cargoes);

            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            cki = Console.ReadKey();

            if (cki.Key == ConsoleKey.D1 || cki.Key == ConsoleKey.NumPad1)
                cargoes[0].Collect(robot);
            else
            if (cki.Key == ConsoleKey.D2 || cki.Key == ConsoleKey.NumPad2)
                cargoes[1].Collect(robot);
            else
            if (cki.Key == ConsoleKey.D3 || cki.Key == ConsoleKey.NumPad3)
                cargoes[2].Collect(robot);
            else
            if (cki.Key != ConsoleKey.D4 || cki.Key != ConsoleKey.NumPad4)
                Console.WriteLine("Unexpected input");



            history.Push(robot.Saveturn());
        }

        public override void Undo()
        {
            robot.Undo(history.Pop());
        }

        public override string ToString()
        {
            return "Generate and collect";
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
            Console.WriteLine(String.Format("Button\tResult\n1-3   \tCollect cargo\n4     \tdont collect"));
        }

    }
}
