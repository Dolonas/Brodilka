using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    abstract class GameItem
    {
        private Point currentPos;
        public Map CurrentMap { get; set; }
        public int SignCode { get; set; }
        public Point PreviousPos { get; set; }

        public Point CurrentPos
        {
            get => currentPos;
            set
            {
                if (value.XPosition > -1 &&
                    value.YPosition > -1 &&
                    value.XPosition < CurrentMap.XSize &&
                    value.YPosition < CurrentMap.YSize)

                {
                    PreviousPos = CurrentPos;
                    currentPos = value;
                }
            }
        }

        public GameItem()
        {
            PreviousPos = new Point ( 0, 0 );
            //CurrMap = new Map();
            //CurrPoint = new Point();
            
        }

        public abstract bool IsItBlock { get; set; }

    }
}
