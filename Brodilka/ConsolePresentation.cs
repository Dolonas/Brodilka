using System;
using System.Collections.Generic;
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
		Console.ForegroundColor = gameItem.ItemColor;
		var previousPos = gameItem is Unit unit ? unit.PreviousPosition : gameItem.CurrPos;
		Console.SetCursorPosition(previousPos.XPos, previousPos.YPos);
		Console.Write(' ');
		Console.SetCursorPosition(gameItem.CurrPos.XPos, gameItem.CurrPos.YPos);
		Console.Write(gameItem.Simbol);
		Console.ForegroundColor = ConsoleColor.White;
	}

	void IDisplayable.DisplayGameInfo(List<GameInfo> infoList)
	{
		foreach (var info in infoList)
		{
			Console.SetCursorPosition(info.GameInfoPosition.XPos, info.GameInfoPosition.YPos);
			Console.Write(info.GameInfoString);
		}
	}

	void IDisplayable.DisplayMap(Map map)
	{
		for (var i = 0; i < map.MapHeight; i++)
		for (var j = 0; j < map.MapWidth; j++)
		{
			Console.SetCursorPosition(j, i);
			if (map.Field[j, i] is not null)
				Console.Write(map.Field[j, i].Simbol);
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
}
