using System;
using Brodilka.Interfaces;

namespace Brodilka;

internal class ConsolePresentation : IDisplayable
{
	private static int _windowWidth;
	private static int _windowHeight;
	private const int MaxWindowWidth = 140;
	private const int MaxWindowHeight = 80;

	private static int WindowXSize
	{
		get => _windowWidth;
		set => _windowWidth = value <= MaxWindowWidth ? value : MaxWindowWidth;
	}

	private static int WindowYSize
	{
		get => _windowHeight;
		set => _windowHeight = value <= MaxWindowHeight ? value : MaxWindowHeight;
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

	void IDisplayable.DisplayMap(Map map)
	{
		for (var i = 0; i < map.MapHeight; i++)
		{
			for (var j = 0; j < map.MapWidth; j++)
			{
				Console.SetCursorPosition(j, i);
				if (map.Field [j, i] is not null)
					Console.Write(map.Field [j, i].Simbol);
			}
		}
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
