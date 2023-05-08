using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka;

internal class ConsolePresentation : IDisplayable
{
	private static int windowXSize;
	private static int windowYSize;
	private static readonly int maxXWindowSize = 140;
	private static readonly int maxYWindowSize = 80;

	public static int WindowXSize
	{
		get => windowXSize;
		set => windowXSize = value <= maxXWindowSize ? value : maxXWindowSize;
	}

	public static int WindowYSize
	{
		get => windowYSize;
		set => windowYSize = value <= maxYWindowSize ? value : maxYWindowSize;
	}

	public ConsolePresentation() : this(maxXWindowSize, maxYWindowSize)
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
		Console.SetWindowSize(WindowXSize, WindowYSize);
		Console.SetBufferSize(WindowXSize, WindowYSize);


		Console.Title = "Brodilka";
	}

	void IDisplayable.Display(GameItem gameItem)
	{
		Console.SetCursorPosition(gameItem.PreviousPos.XPosition, gameItem.PreviousPos.YPosition);
		Console.Write(" ");
		Console.SetCursorPosition(gameItem.CurrentPosition.XPosition, gameItem.CurrentPosition.YPosition);
	}
}
