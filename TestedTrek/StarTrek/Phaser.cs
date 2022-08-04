using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek
{
    class Phaser : Weapon
    {
        private int _range = 4000;

        /// <inheritdoc />
        protected override bool CanFire(Galaxy wg, int ammunition, Func<int, int> Rnd)
        {
            int amount = int.Parse(wg.Parameter("amount"));
            return ammunition >= amount;
        }

        public int FireWeapon(Galaxy wg, int energy, Func<int, int> Rnd)
        {
            int amount = int.Parse(wg.Parameter("amount"));
            Klingon enemy = (Klingon)wg.Variable("target");

            if (energy >= amount)
            {
                int distance = enemy.Distance();
                if (distance > _range)
                {
                    wg.WriteLine("Klingon out of range of phasers at " + distance + " sectors...");
                }
                else
                {
                    var damage = getDamage(amount, distance, Rnd);

                    wg.WriteLine("Phasers hit Klingon at " + distance + " sectors with " + damage + " units");

                    if (hurtEnemy(enemy, damage))
                    {
                        enemy.SetEnergy(enemy.GetEnergy() - damage);
                        wg.WriteLine("Klingon has " + enemy.GetEnergy() + " remaining");
                    }
                    else
                    {
                        wg.WriteLine("Klingon destroyed!");
                        enemy.Delete();
                    }
                }

                return amount;

            }
            else
            {
                wg.WriteLine("Insufficient energy to fire phasers!");
            }

            return 0;
        }

        private bool hurtEnemy(Klingon enemy, int damage)
        {
            return damage < enemy.GetEnergy();
        }

        private int getDamage(int amount, int distance, Func<int, int> Rnd)
        {
             var dmg = amount - (((amount / 20) * distance / 200) + Rnd(200));

             if (dmg < 1) dmg = 1;

             return dmg;
        }

    }

}
