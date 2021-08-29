using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Apple : Bonus
    {
        private readonly int appleSignCode = 36;
        private readonly int speedUp = 0;
        private readonly int healthUp = 70;

        public Apple()
        {

        }

        public Apple(Pos currPos, Map currMap) : base(currPos, currMap)
        {
            this.SignCode = appleSignCode;
            this.SpeedUpForPlayer = speedUp;
            this.HealthUpForPlayer = healthUp;
        }
    }
}
