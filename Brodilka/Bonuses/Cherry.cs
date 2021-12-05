using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Cherry : Bonus
    {
        private readonly int cherrySignCode = 31;
        private readonly int speedUp = 5;
        private readonly int healthUp = 0;

        public Cherry()
        {

        }

        public Cherry(Point currPos, Map currMap) : base(currPos, currMap)
        {
            this.SignCode = cherrySignCode;
            this.SpeedUpForPlayer = speedUp;
            this.HealthUpForPlayer = healthUp;
        }

    }
}
