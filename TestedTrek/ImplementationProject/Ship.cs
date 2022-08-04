using System;

namespace ImplementationProject
{
    public class Ship
    {
        public int SubsystemCount { get; set; }
        public Shield Shield { get; set; }

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

        public void TransferEnergyToShield(int units)
        {
            Shield.AcceptPower(100);
        }
    }
}
