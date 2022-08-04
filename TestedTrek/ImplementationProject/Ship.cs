using System;

namespace ImplementationProject
{
    public class Ship
    {
        private Subsystem[] subsystems = new Subsystem[] { new Subsystem() };

        public int SubsystemCount { get; set; }
        public Shield Shield { get; set; }

        public int Reserves { get; private set; } = 10000;

        public static Random generator = new Random();
        

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
            if (Reserves - units < 0)
            {
                throw new Exception("Not enough energy");
            }

            Reserves -= units;

            Shield.AcceptPower(100);
        }

        public void RaiseShield()
        {
            Shield.Raise();
        }
    }
}
