using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Point
    {
        private int xPosition = 0;
        private int yPosition = 0;

        
        public int XPosition
        {
            get => xPosition;
            set => xPosition = value;
        }

        public int YPosition
        {
            get => yPosition;
            set => yPosition = value;
        }

        public Point() : this (0,0)
        {

        }

        public Point(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;
        }
    }
}
