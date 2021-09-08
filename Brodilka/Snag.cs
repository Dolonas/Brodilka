using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal abstract class Snag : GameItem
    {
        private bool isItBlock;
        public override bool IsItBlock { get => isItBlock; set => this.isItBlock = value; }

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
