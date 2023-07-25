using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class ConsolePresentation: IDisplayble
    {
        private static int _windowXSize;
        private static int _windowYSize;
        private const  int MaxXWindowSize = 90;
        private const int MaxYWindowSize = 30;

        private static int WindowXSize
        {
            get => _windowXSize;
            set => _windowXSize = value <= MaxXWindowSize ? value : MaxXWindowSize;
        }

        private static int WindowYSize
        {
            get => _windowYSize;
            set => _windowYSize = value <= MaxYWindowSize ? value : MaxYWindowSize;
        }

        public ConsolePresentation() : this (MaxXWindowSize, MaxYWindowSize)
        {
        }

        public ConsolePresentation(int xSize, int ySize)
        {
            WindowXSize = xSize;
            WindowYSize = ySize;
            DisplayInitialize();
        }

        private void DisplayInitialize()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            WindowXSize = MaxXWindowSize;
            WindowYSize = MaxYWindowSize;
            Console.SetWindowSize(WindowXSize, WindowYSize);
            Console.SetBufferSize(WindowXSize, WindowYSize);
            

            Console.Title = "Brodilka";
            
        }

         void IDisplayble.Display(GameItem gameItem)
        {
            Console.SetCursorPosition(gameItem.CurrPoint.XPos, gameItem.CurrPoint.YPos);
            var str = Char.ConvertFromUtf32(Convert.ToUInt16(gameItem.SignCode));
            Console.Write(str);

        }

    }
}
