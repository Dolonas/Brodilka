
namespace Brodilka;
    public class Map
    {
        private int xSize;
        private int ySize;
        
        public int XSize 
        {
            get => xSize;
            set => xSize = value is > 30 and < 160 ? value : 60;
        }
        public int YSize
        {
            get => ySize;
            set => ySize = value is > 30 and < 160 ? value : 60;
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
