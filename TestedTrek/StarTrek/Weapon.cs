using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrek
{
    abstract class Weapon
    {
        protected string name;

        protected abstract bool CanFire(Galaxy wg, int ammunition, Func<int, int> Rnd);

        public int FireWeapon(Galaxy wg, int ammunition, Func<int, int> Rnd)
        {
            var enemy = (Klingon)wg.Variable("target");
            return CanFire(wg, ammunition, Rnd) ? TryFire(wg, ammunition, Rnd) : 0;
        }

        private int TryFire(Galaxy wg, int ammunition, Func<int, int> Rnd)
        {
            return 0;
        }
    }
}
