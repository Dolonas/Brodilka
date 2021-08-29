using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Pos
    {
        private int xPos = 0;
        private int yPos = 0;

        
        public int XPos
        {
            get
            {
                return xPos;
            }
            set
            {
                xPos = value < 0 && value > 200 ? 0 : value;
            }
        }

        public int YPos
        {
            get
            {
                return yPos;
            }
            set
            {
                yPos = value < 0 && value > 200 ? 0 : value;
            }
        }

        public Pos() : this (0,0)
        {

        }

        public Pos(int xPos, int yPos)
        {
            XPos = xPos;
            YPos = yPos;
        }
    }
}
