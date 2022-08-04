using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationProject
{
    public class Ship
    {
        public int SubsystemCount { get; set; }
        public static Random generator = new Random();
        private Subsystem[] subsystems = new Subsystem[] { new Subsystem() };

        public Ship()
        {
        }

        public int GetRandomValue(int maximum)
        {
            return generator.Next(maximum);
        }

        public Subsystem GetRandomSystem()
        {
            return subsystems[GetRandomValue(SubsystemCount)];
        }
    }
}
