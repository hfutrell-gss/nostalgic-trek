using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationProject
{
    public class Subsystem
    {
        private string subsystemName;
        private int repairRate;

        public Subsystem(string subsystemName = "Unknown", int repairRate = 500)
        {
            this.subsystemName = subsystemName;
            this.repairRate = repairRate;
        }

        public int Damage { get; set; }
        public bool IsOperational { get { return Damage == 0; } }

        public void TakeDamage(int amount)
        {
            Damage += amount;
        }

        public void Repair(int days)
        {
            Damage -= repairRate * days;
        }
    }
}
