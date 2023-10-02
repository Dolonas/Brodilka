using System;
using System.Linq;
using System.Threading;
using Brodilka.Interfaces;
using Brodilka.Utilits;

namespace Brodilka;

public enum Command
{
	Left, Up, Right, Down, LeftUp, LeftDown, RightUp, RightDown, Attack1, Stop, Redraw, Escape, Non
}

public enum ItemColor
{
	White, Black, Blue, Cyan, Gray, Green, Magenta, Red, Yellow, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta, DarkRed, DarkYellow
}

internal class GameProcessor
{
	private const string FilePass = "../../../Data/Maps/map03.dat";

	internal GameProcessor()
	{
		CurrMap = new Map(MapData.ReadMapAsync(FilePass)?.Result);
		ConsolePresents = new ConsolePresentation(CurrMap.Width, CurrMap.Height);
		InitializeGameInfo();
	}

	private IDisplayable ConsolePresents { get; }
	private Map CurrMap { get; }
	internal GameInfoList InfoList { get; set; }

	internal void Run()
	{
		DisplayAll();
		var receive = Command.Non;
		if (Console.KeyAvailable)
			receive = GetKeyboardReceive();

		while (receive != Command.Escape)
		{
			var makeSound = ConsolePresents.MakeSound;
			CurrMap.CalculateMoves(makeSound);

			receive = GetKeyboardReceive();
			//if (receive == Command.Redraw) ConsolePresents.DisplayMap(CurrMap);
			if (CurrMap.SolvePlayerCollisions(receive, makeSound))
				break;
			DisplayAll();
			Thread.Sleep(200);
		}

		Environment.Exit(0);
	}

	private void DisplayAll()
	{
		foreach (var gameItem in CurrMap.Items.Where(gi => gi is not null && gi.IsExist))
			ConsolePresents.Display(gameItem);
		ConsolePresents.DisplayGameInfo(InfoList);
		CurrMap.SyncItemsOnField();
	}

	private Command GetKeyboardReceive()
	{
		ConsoleKeyInfo cki;
		if (Console.KeyAvailable)
			cki = Console.ReadKey();
		else
			return Command.Non;

		return cki.Key switch
		{
			ConsoleKey.RightArrow => Command.Right,
			ConsoleKey.LeftArrow => Command.Left,
			ConsoleKey.UpArrow => Command.Up,
			ConsoleKey.DownArrow => Command.Down,
			ConsoleKey.Delete => Command.Redraw,
			_ => cki.Key == ConsoleKey.Escape ? Command.Escape : Command.Stop
		};
	}

	private void InitializeGameInfo()
	{
		var infoLine = CurrMap.Field.GetLength(1) + 1;
		InfoList = new GameInfoList(infoLine, 2);
		var gInfo1 = new GameInfo("Player name:", ItemColor.Cyan);
		var gInfo2 = new GameInfo(CurrMap.CurrPlayer.Name, ItemColor.Yellow);
		var gInfo3 = new GameInfo("Health:", ItemColor.White);
		var gInfo4 = new GameInfo(CurrMap.CurrPlayer.Health.ToString(), ItemColor.White);
		InfoList.Add(gInfo1);
		InfoList.Add(gInfo2);
		InfoList.Add(gInfo3);
		InfoList.Add(gInfo4);
	}
}
