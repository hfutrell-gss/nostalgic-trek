using System;

namespace ImplementationProject
{
    public class Ship
    {
        private Subsystem[] subsystems = new Subsystem[] { new Subsystem("Phaser", 300), new Subsystem("Shields", 500), new Subsystem("Warp engines", 200) };

        public int SubsystemCount { get; set; }
        private Shield Shield { get; set; }

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

        public Ship() : this(new Shield()) { }

        public Ship(Shield shield)
        {
            Shield = shield;
            SubsystemCount = subsystems.Length;
        }

        public int GetRandomValue(int maximum)
        {
            return generator.Next(maximum);
        }

        public Subsystem GetRandomSystem(Func<int, int> randomizer)
        {
            return subsystems[randomizer(SubsystemCount)];
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

        public void TakeDamage(int amount, Func<int, int> r = null)
        {
            if (Shield.IsRaised())
                amount = Shield.AcceptDamage(amount);

            if (r is null)
                r = GetRandomValue;

            subsystems[r(SubsystemCount)].TakeDamage(amount);
        }

        public void RaiseShield()
        {
            Shield.Raise();
        }
    }
}
