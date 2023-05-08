using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Wolf : Enemy
    {

        public Wolf() : this (new Point(0,0), new Map())
        {

        }
        public Wolf(Point currPos, Map currMap) : base(currPos, currMap)
        {
            Damage = 20;
            Health = 40;
            SignCode = 87;
            this.IsItBlock = false;
            

        }
    }
}
