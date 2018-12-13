using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot2game.Classes;
using Robot2game.Classes.RobotTypes;
using Robot2game.Classes.CargoTypes;

namespace Robot2GameTest
{
    [TestClass]
    public class RobotTest
    {
        Robot robot;

        [TestInitialize]
        public void Init()
        {
            robot = new ScienceRobot("1");
        }

        [TestMethod]
        public void MoveTest()
        {
            float energy = robot.Energy;
            robot.Move();
            Assert.IsTrue(energy > robot.Energy);
        }

        [TestMethod]
        public void RobotCollectTest()
        {
            Cargo cargo1 = new StandartCargo();
            Cargo cargo2 = new StandartCargo();
            ushort weight = robot.Load;
            int cost = robot.Cost;

            ushort w1 = cargo1.Weight;
            ushort w2 = cargo2.Weight;

            ushort c1 = cargo1.Cost;
            ushort c2 = cargo2.Cost;

            robot.Collect(cargo1);
            robot.Collect(cargo2);

            Assert.IsTrue((robot.Load == (weight + w1 + w2)) && (robot.Cost == (cost + c1 + c2)));
        }

        [TestMethod]
        public void TakeDamageTest()
        {
            robot = new ScienceRobot("1");
            float en = robot.Energy;
            robot.TakeDamage(30);
            Assert.IsTrue(robot.Energy == en - 30);
        }

        [TestMethod]
        public void CheckEnergyTest()
        {
            robot = new ScienceRobot("!");
            Assert.IsFalse(robot.CheckEnergy());
            robot.TakeDamage(50000);
            Assert.IsTrue(robot.CheckEnergy());
        }

        [TestMethod]
        public void DeletePerishablesTest()
        {
            robot = new WorkerRobot("1");
            Cargo pcargo = new PerishableCargo();
            short shelflife = pcargo.ShelfLife;

            ushort load = robot.Load;

            robot.Collect(pcargo);

            for (int i = 0; i <= shelflife; i++)
                robot.Move();

            Assert.AreEqual(load, robot.Load);
        }

        [TestMethod]
        public void SaveUndoTest()
        {
            robot = new ScienceRobot("");
            float energy = robot.Energy;
            int load = robot.Load;
            float cost = robot.Cost;

            robot.Undo(robot.Saveturn());

            Assert.AreEqual(energy, robot.Energy);
            Assert.AreEqual(load, robot.Load);
            Assert.AreEqual(cost, robot.Cost);
        }

        [TestMethod]
        public void CargoCollectTest()
        {
            Cargo c = new StandartCargo();

            ushort wei = robot.Load;
            int cost = robot.Cost;

            c.Collect(robot);

            Assert.IsTrue(wei <= robot.Load && cost <= robot.Cost);
        }

        [TestMethod]
        public void RobotHistoryTest()
        {
            RobotHistory rh = new RobotHistory();
            rh.Push(robot.Saveturn());
            robot.Collect(new ToxicCargo());

            float energy = robot.Energy;
            int load = robot.Load;
            float cost = robot.Cost;

            robot.Undo(rh.Pop());

            Assert.IsTrue(energy == robot.Energy);
            Assert.IsTrue(load >= robot.Load);
            Assert.IsTrue(cost >= robot.Cost);
        }
    }
}
