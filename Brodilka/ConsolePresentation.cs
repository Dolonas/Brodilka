using System;
using System.Collections.Generic;
using System.Diagnostics;
using Brodilka.GameItems;
using Brodilka.GameItems.Units;
using Brodilka.Interfaces;

namespace Brodilka;

internal class ConsolePresentation : IDisplayable
{
	private const int MaxWindowWidth = 140;
	private const int MaxWindowHeight = 80;
	private static int _windowWidth;
	private static int _windowHeight;

	public ConsolePresentation(int width, int height)
	{
		WindowWidth = width;
		WindowHeight = height;
		DisplayInitialize();
	}

	private static int WindowWidth
	{
		get => _windowWidth;
		set => _windowWidth = value <= MaxWindowWidth ? value : MaxWindowWidth;
	}

	private static int WindowHeight
	{
		get => _windowHeight;
		set => _windowHeight = value <= MaxWindowHeight ? value : MaxWindowHeight;
	}

	void IDisplayable.Display(GameItem gameItem)
	{
		Console.ForegroundColor = ConverToConsoleColor(gameItem.ItemColor);
		var previousPos = gameItem is Unit unit ? unit.PreviousPosition : gameItem.Pos;
		Console.SetCursorPosition(previousPos.XPos, previousPos.YPos);
		Console.Write(' ');
		Console.SetCursorPosition(gameItem.Pos.XPos, gameItem.Pos.YPos);
		Console.Write(gameItem.Simbol);
		Console.ForegroundColor = ConsoleColor.DarkGray;
	}

	void IDisplayable.DisplayMap(Map map)
	{
		for (var i = 0; i < map.Height; i++)
		for (var j = 0; j < map.Width; j++)
		{
			Console.SetCursorPosition(j, i);
			if (map.Field[j, i] is not null)
				Console.Write(map.Field[j, i].Simbol);
		}
	}

	void IDisplayable.DisplayGameInfo(GameInfoList infoList)
	{
		var startXPos = infoList.StartXPosition;
		Console.SetCursorPosition(startXPos, infoList.InfoLinePosition);
		Console.WriteLine(new string(' ', _windowWidth - 10));

		foreach (var info in infoList.List)
		{
			Console.SetCursorPosition(startXPos, infoList.InfoLinePosition);
			Console.ForegroundColor = ConverToConsoleColor(info.InfoColor);
			Console.Write(info.GameInfoString);
			Console.ForegroundColor = ConsoleColor.DarkGray;
			startXPos += info.GameInfoString.Length + 1;
		}
		Console.SetCursorPosition(0, 0);
	}

	void IDisplayable.Redraw()
	{
		Console.Clear();
	}

	void IDisplayable.MakeSound(int frequency, int duration)
	{
		Console.Beep(frequency, duration);
	}

	private static void DisplayInitialize()
	{
		Console.BackgroundColor = ConsoleColor.Black;
		Console.ForegroundColor = ConsoleColor.White;
		Console.Clear();
		Console.SetWindowSize(WindowWidth, WindowHeight);
		Console.SetBufferSize(WindowWidth, WindowHeight);
		Console.Title = "Brodilka";
		Console.CursorVisible = false;
	}

	private ConsoleColor ConverToConsoleColor(ItemColor itemColor)
	{
		return (itemColor) switch
		{
			ItemColor.White => ConsoleColor.White,
			ItemColor.Black => ConsoleColor.Black,
			ItemColor.Blue => ConsoleColor.Blue,
			ItemColor.Cyan => ConsoleColor.Cyan,
			ItemColor.Gray => ConsoleColor.Gray,
			ItemColor.Green => ConsoleColor.Green,
			ItemColor.Magenta => ConsoleColor.Magenta,
			ItemColor.Red => ConsoleColor.Red,
			ItemColor.Yellow => ConsoleColor.Yellow,
			ItemColor.DarkBlue => ConsoleColor.DarkBlue,
			ItemColor.DarkCyan => ConsoleColor.DarkCyan,
			ItemColor.DarkGray => ConsoleColor.DarkGray,
			ItemColor.DarkGreen => ConsoleColor.DarkGreen,
			ItemColor.DarkMagenta => ConsoleColor.DarkMagenta,
			ItemColor.DarkRed => ConsoleColor.DarkRed,
			ItemColor.DarkYellow => ConsoleColor.DarkYellow,
			_ => throw new ArgumentOutOfRangeException(nameof(itemColor), itemColor, null)
		};
	}

	void IDisplayable.GoToWinScreen()
	{
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Cyan;
		Console.SetCursorPosition(WindowWidth/2 - 8, WindowHeight / 2);
		Console.WriteLine("Y o u   w i n !");
	}

	void IDisplayable.ShowGameOverScreen()
	{
		Console.Clear();
		Console.ForegroundColor = ConsoleColor.Red;
		Console.SetCursorPosition(WindowWidth/2 - 8, WindowHeight / 2);
		Console.WriteLine("G a m e   O v e r !");
	}


}
