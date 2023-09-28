﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
		var previousPos = gameItem is Unit unit ? unit.PreviousPosition : gameItem.CurrPos;
		Console.SetCursorPosition(previousPos.XPos, previousPos.YPos);
		Console.Write(' ');
		Console.SetCursorPosition(gameItem.CurrPos.XPos, gameItem.CurrPos.YPos);
		Console.Write(gameItem.Simbol);
		Console.ForegroundColor = ConsoleColor.DarkGray;
	}

	void IDisplayable.DisplayGameInfo(List<GameInfo> infoList)
	{
		foreach (var info in infoList)
		{
			Console.SetCursorPosition(info.GameInfoPosition.XPos, info.GameInfoPosition.YPos);
			Console.ForegroundColor = ConverToConsoleColor(info.InfoColor);
			Console.Write(info.GameInfoString);
			Console.ForegroundColor = ConsoleColor.DarkGray;
		}
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
}
