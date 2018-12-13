using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot2game.Classes;
using Robot2game.Classes.RobotTypes;
using Robot2game.Classes.GameCommands;

namespace Robot2GameTest
{
    [TestClass]
    public class CommandsTest
    {
        Robot robot;
        GameController contr;

        [TestInitialize]
        public void Init()
        {
            robot = new ScienceRobot("");
            contr = new GameController(robot);
        }

        [TestMethod]
        public void GameControllerTest()
        {
            contr.SetCommand(null);
            Assert.IsNull(contr.Command);
            contr.SetCommand(new GenCollectCommand(robot));
            Assert.IsInstanceOfType(contr.Command, typeof(GenCollectCommand));
            Command c = new MoveCommand(robot);
            contr.SetCommand(c);
            Assert.IsInstanceOfType(contr.Command, typeof(MoveCommand));
            float e = robot.Energy;
            contr.Execute();
            Assert.AreNotEqual(e, robot.Energy);
            contr.Undo();
            Assert.AreEqual(e, robot.Energy, 3D);
        }


    }
}
