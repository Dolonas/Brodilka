using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    abstract class GameItem
    {
        private Pos currPos;

        public Map CurrMap { get; set; }

        public int SignCode { get; set; }
        public Pos CurrPos
        {
            get
            {
                return currPos;
            }
            set
            {
                if (value.XPos > -1 &&
                    value.YPos > -1 &&
                    value.XPos < CurrMap.XSize &&
                    value.YPos < CurrMap.YSize)

                {
                    currPos = value;
                }
            }
        }

        public GameItem()
        {
            CurrMap = new Map();
            CurrPos = new Pos();
            
        }

        public abstract bool IsItBlock { get; set; }

    }
}
