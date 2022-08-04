using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek
{
    class Photon : Weapon
    {
        /// <inheritdoc />
        protected override bool CanFire(Galaxy wg, int ammunition, Func<int, int> Rnd)
        {
            return ammunition > 0;
        }

        public int FireWeapon(Galaxy wg, int t, Func<int, int> Rnd)
        {
            Klingon enemy = (Klingon) wg.Variable("target");
            if (t  > 0) {
                int distance = enemy.Distance();
                if ((Rnd(4) + ((distance / 500) + 1) > 7)) {
                    wg.WriteLine("Torpedo missed Klingon at " + distance + " sectors...");
                } else {
                    int damage = 800 + Rnd(50);
                    wg.WriteLine("Photons hit Klingon at " + distance + " sectors with " + damage + " units");
                    if (damage < enemy.GetEnergy()) {
                        enemy.SetEnergy(enemy.GetEnergy() - damage);
                        wg.WriteLine("Klingon has " + enemy.GetEnergy() + " remaining");
                    } else {
                        wg.WriteLine("Klingon destroyed!");
                        enemy.Delete();
                    }
                }  
                return 1;


            } else {
                wg.WriteLine("No more photon torpedoes!");
            }

            return 0;
        }
    }
}
