using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class ConsolePresentation: IDisplayble
    {
        private static int windowXSize;
        private static int windowYSize;
        private static readonly int maxXWindowSize = 140;
        private static readonly int maxYWindowSize = 80;
        public static int WindowXSize
        {
            get => windowXSize;
            set
            {
                if (value <= maxXWindowSize)
                {
                    windowXSize = value;
                }
                else
                {
                    windowXSize = maxXWindowSize;
                }
            }
        }
        public static int WindowYSize
        {
            get => windowYSize;
            set
            {
                if (value <= maxYWindowSize)
                {
                    windowYSize = value;
                }
                else
                {
                    windowYSize = maxYWindowSize;
                }
            }

        }

        public ConsolePresentation() : this (maxXWindowSize, maxYWindowSize)
        {
        }

        public ConsolePresentation(int xSize, int ySize)
        {
            WindowXSize = xSize;
            WindowYSize = ySize;
            DisplayInitialize();
        }

        internal void DisplayInitialize()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            WindowXSize = WindowXSize;
            WindowYSize = WindowYSize;
            Console.SetWindowSize(WindowXSize, WindowYSize);
            Console.SetBufferSize(WindowXSize, WindowYSize);
            

            Console.Title = "Brodilka";
            
        }

         void IDisplayble.Display(GameItem gameItem)
        {
            Console.SetCursorPosition(gameItem.CurrPoint.XPos, gameItem.CurrPoint.YPos);
            string str = Char.ConvertFromUtf32(Convert.ToUInt16(gameItem.SignCode));
            Console.Write(str);

        }

    }
}
