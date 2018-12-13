using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot2game.Classes.Factories;
using Robot2game.Classes;
using Robot2game.Classes.CargoTypes;
using Robot2game.Classes.RobotTypes;

namespace Robot2GameTest
{
    [TestClass]
    public class FactoriesTest
    {
        RobotFactory rf;
        CargoFactory cf;
        RobotCreator rc;
        [TestMethod]
        public void TestCargoFactory()
        {
            CargoFactory cf = new CargoFactory();

            CargoDecorator cd = cf.Create();

            bool res = (cd is StandartCargoDecorator || cd is EncryptedCargoDecorator) && (cd.Cargo is StandartCargo
                        || cd.Cargo is PerishableCargo || cd.Cargo is ToxicCargo);

            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestRobotFactories()
        {
            rf = new CyborgRobotFactory();

            Assert.IsInstanceOfType(rf.Generate(""), typeof(CyborgRobot));

            rf = new ScienceRobotFactory();

            Assert.IsInstanceOfType(rf.Generate(""), typeof(ScienceRobot));

            rf = new WorkerRobotFactory();

            Assert.IsInstanceOfType(rf.Generate(""), typeof(WorkerRobot));
        }

        [TestMethod]
        public void TestRobotCreator()
        {
            rc = new RobotCreator();

            Robot r = rc.Create("");

            bool res = r is CyborgRobot || r is ScienceRobot || r is WorkerRobot;

            Assert.IsTrue(res);
        }
    }
}
