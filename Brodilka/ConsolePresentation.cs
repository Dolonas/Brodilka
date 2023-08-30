using System;
using Brodilka.Interfaces;

namespace Brodilka;

internal class ConsolePresentation : IDisplayable
{
	private static int _windowXSize;
	private static int _windowYSize;
	private const int MaxXWindowSize = 140;
	private const int MaxYWindowSize = 80;

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

	public ConsolePresentation(int xSize, int ySize)
	{
		WindowXSize = xSize;
		WindowYSize = ySize;
		DisplayInitialize();
	}

	private static void DisplayInitialize()
	{
		Console.BackgroundColor = ConsoleColor.Black;
		Console.ForegroundColor = ConsoleColor.White;
		Console.Clear();
		Console.SetWindowSize(WindowXSize, WindowYSize);
		Console.SetBufferSize(WindowXSize, WindowYSize);
		Console.Title = "Brodilka";
		Console.CursorVisible = false;
	}

	void IDisplayable.Display(GameItem gameItem)
	{
		Console.ForegroundColor = gameItem.ItemColor;
		Console.SetCursorPosition(gameItem.PreviousPosition.XPos, gameItem.PreviousPosition.YPos);
		Console.Write(' ');
		Console.SetCursorPosition(gameItem.CurrentPos.XPos, gameItem.CurrentPos.YPos);
		Console.WriteLine(gameItem.Simbol);
		Console.ForegroundColor = ConsoleColor.White;
	}

	void IDisplayable.Redraw()
	{
		Console.Clear();
	}

	void IDisplayable.MakeSound(int frequency, int duration)
	{
		Console.Beep(frequency, duration);
	}
}
