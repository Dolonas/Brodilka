using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal abstract class Bonus : GameItem
    {
        public int SpeedUpForPlayer { get; set; }
        public int HealthUpForPlayer { get; set; }
        public override bool IsItBlock { get => false; set => this.IsItBlock = value; }

        public Bonus() : this(new Pos(0, 0), new Map())
        {

        }

        public Bonus(Pos currPos, Map currMap)
        {
            this.CurrMap = currMap;
            this.CurrPos = currPos;
            
            this.IsItBlock = false;

        }
    }
}
