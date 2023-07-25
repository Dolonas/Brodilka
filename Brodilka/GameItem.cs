using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    abstract class GameItem
    {
        private Point currPos;

        protected Map CurrMap { get; set; }

        public int SignCode { get; set; }
        public Point CurrPoint
        {
            get => currPos;
            protected set
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
            //CurrMap = new Map();
            //CurrPoint = new Point();
            
        }

        public abstract bool IsItBlock { get; set; }

    }
}
