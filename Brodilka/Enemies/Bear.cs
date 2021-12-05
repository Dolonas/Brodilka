using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Bear : Enemy
    {
        public Bear() : this(new Point(0, 0), new Map())
        {

        }
        public Bear(Point currPos, Map currMap) : base(currPos, currMap)
        {
            Damage = 40;
            Health = 100;
            SignCode = 220;
            this.IsItBlock = false;

        }
    }
}
