using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    abstract class Robot
    {
        private const float defaultbatterycap = 100;
        private const short defaultloadcap = 1000;
        private const float defaultenergyperturn = 8;

        protected float batterycoef;
        protected float loadcoef;
        protected float consumcoef;
            
        private String avatarpath;
        private string name;
        protected string type;
        protected string legend;
        protected ushort decodechance;

        private ushort load;
        private int cost;
        protected float energy;
        
        protected ushort DecodeChance
        {
            get
            {
                return decodechance != default(ushort) ? decodechance < 100 ? decodechance : (ushort)100 : (ushort)0;
            }
        }
        protected float MaxBattery
        {
            get {
                if (batterycoef != default(ushort))
                    return defaultbatterycap * batterycoef;
                return defaultbatterycap;
            }
        }
        protected float MaxLoad
        {
            get
            {
                if (loadcoef != default(ushort))
                    return defaultloadcap * loadcoef;
                return defaultloadcap;
            }
        }
        protected float TurnConsumption
        {
            get
            {
                return consumcoef == default(float) ? defaultenergyperturn : defaultenergyperturn * consumcoef;
            }
        }
        protected float EnergyConsumptionMul
        {
            get
            {
                return load / MaxLoad + 1;
            }
        }
        public string RobotInformation
        {
            get
            {
                return String.Format("Robot Type — {0}, Earned — {1}\tE : {2}% | L : {3}%", type, cost.ToString(), energy / MaxBattery, load /MaxLoad);
            }
        }
        public string Type
        {
            get { return type; }
        }
        public string Legend
        {
            get { return legend; }
        }

        public Robot(string name)
        {
            this.name = name;
            load = 0;
            cost = 0;
        }
        public bool CheckEnergy()     // true if no energy
        {
            if (load / MaxLoad >= 0.8)
            {
                Random r = new Random();
                energy = r.Next(0, 100) <= 30 ? 0 : energy;
            }
            if (energy == 0)
                return true;
            return false;
        }
        public void Move() // TODO
        {
            float consumtion = TurnConsumption * EnergyConsumptionMul;
            energy = consumtion < energy ? energy - consumtion : 0;

            // TODO check perishable cargoes
        }

        public RobotMemento Saveturn()
        {
            return new RobotMemento(energy, load, cost);
        }
        public void Undo(RobotMemento rm)
        {
            energy = rm.Energy;
            load = rm.Load;
            cost = rm.Cost;
        }
        public void Collect(Cargo cargo)
        {
            cost += cargo.Cost;
            load += cargo.Weight;
        }
        public void TakeDamage(float energy)
        {
            this.energy -= energy;
        }
        public bool Encrypt()
        {
            return (new Random()).Next(1, 100) <= decodechance;
        }
    }
}
