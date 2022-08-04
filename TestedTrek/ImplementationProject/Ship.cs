using System;

namespace ImplementationProject
{
    public class Ship
    {
        private Subsystem[] subsystems = new Subsystem[] { new Subsystem("Phaser", 300), new Subsystem("Shields", 500), new Subsystem("Warp engines", 200) };

        public int SubsystemCount { get; set; }
        public Shield Shield { get; set; }

        public int Reserves { get; private set; } = 10000;
        public bool IsFullyOperational 
        { 
            get 
            {
                foreach (Subsystem subsystem in subsystems)
                {
                    if (!subsystem.IsOperational)
                        return false;
                }
                return true;
            } 
        }

        public static Random generator = new Random();
        

        public Ship()
        {
            SubsystemCount = subsystems.Length;
            Shield = new Shield();
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

        public void TakeDamage(int amount)
        {
            if (Shield.IsRaised())
                amount = Shield.AcceptDamage(amount);
            subsystems[GetRandomValue(SubsystemCount)].TakeDamage(amount);
        public void RaiseShield()
        {
            Shield.Raise();
        }
    }
}
