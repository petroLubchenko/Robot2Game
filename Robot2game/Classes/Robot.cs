using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot2game.Classes
{
    public abstract class Robot
    {
        private const float defaultbatterycap = 100;
        private const short defaultloadcap = 1000;
        private const float defaultenergyperturn = 3;

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

        private Dictionary<Cargo, int> perishables;


        public float Energy
        {
            get
            {
                return energy;
            }
        }
        public ushort Load
        {
            get
            {
                return load;
            }
        }
        public int Cost
        {
            get
            {
                return cost;
            }
        }
        
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
                return String.Format("Robot Type — {0}, Earned — {1}\tE : {2}% | L : {3}%", type, cost.ToString(), energy / MaxBattery * 100, load / MaxLoad * 100);
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

            perishables = new Dictionary<Cargo, int>();
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
        public void Move() 
        {
            float consumtion = TurnConsumption * EnergyConsumptionMul;
            energy = consumtion < energy ? energy - consumtion : 0;

            foreach (var elem in perishables.Keys.ToArray())
                if (++(perishables[elem]) > elem.Shelflife)
                {
                    perishables.Remove(elem);
                    cost -= elem.Cost;
                    load -= elem.Weight;
                }


        }

        public RobotMemento Saveturn()
        {
            return new RobotMemento(energy, load, cost, batterycoef, loadcoef, consumcoef);
        }
        public void Undo(RobotMemento rm)
        {
            energy = rm.Energy;
            load = rm.Load;
            cost = rm.Cost;
            batterycoef = rm.batterycoef;
            loadcoef = rm.loadcoef;
            consumcoef = rm.consumcoef;
        }
        public void Collect(Cargo cargo)
        {
            cost += cargo.Cost;
            load += cargo.Weight;

            if (cargo.Shelflife != -1)
                perishables.Add(cargo, 0);

            if (load / MaxLoad > 1)
            {
                Console.WriteLine("Robot cant collect this cargo");
                cost -= cargo.Cost;
                load -= cargo.Weight;
            }

        }
        public void TakeDamage(float energy)
        {
            this.energy -= energy;
            if (this.energy < 0)
                this.energy = 0;
        }
        public bool Encrypt()
        {
            return (new Random()).Next(1, 100) <= decodechance;
        }
    }
}
