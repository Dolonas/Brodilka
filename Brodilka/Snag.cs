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

        public Snag() : this (new Point(0,0), new Map())
        {

        }
        
        public Snag(Point currPoint, Map currMap)
        {
            this.CurrMap = currMap;
            this.CurrPoint = currPoint;
            
            this.IsItBlock = true;
        }
    }
}
