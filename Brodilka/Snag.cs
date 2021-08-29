using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal abstract class Snag : GameItem
    {
        public override bool IsItBlock { get => false; set => this.IsItBlock = value; }

        public Snag() : this (new Pos(0,0), new Map())
        {

        }
        
        public Snag(Pos currPos, Map currMap)
        {
            this.CurrPos = currPos;
            this.CurrMap = currMap;
            this.IsItBlock = true;
        }
    }
}
