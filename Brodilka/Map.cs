using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    public class Map
    {
        private int xSize;
        private int ySize;
        
        public int XSize 
        {
            get 
            {
                return xSize;
            }
            set 
            {
                if (value > 30 && value < 160)
                {
                    xSize = value;
                }
                else
                {
                    xSize = 60;
                }
            }
        }
        public int YSize
        {
            get
            {
                return ySize;
            }
            set
            {
                if (value > 30 && value < 160)
                {
                    ySize = value;
                }
                else
                {
                    ySize = 60;
                }
            }
        }
        public Map() : this (60, 40)
        {            
        }

        public Map(int xSize, int ySize)
        {
            XSize = xSize;
            YSize = ySize;
                
        }
    }
}
