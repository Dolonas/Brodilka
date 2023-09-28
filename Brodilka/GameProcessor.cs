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

internal class GameProcessor
{
	private const string FilePass = "../../../Data/Maps/map03.dat";

	internal GameProcessor()
	{
		CurrMap = new Map(MapData.ReadMapAsync(FilePass)?.Result);
		//CurrMap.SyncItemsOnField(Items);
		//SortItems();
		ConsolePresents = new ConsolePresentation(CurrMap.MapWidth, CurrMap.MapHeight);
	}

	private IDisplayable ConsolePresents { get; }

	private Map CurrMap { get; }

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
			CurrMap.SolvePlayerCollisions(receive, makeSound);
			DisplayAll();
			Thread.Sleep(200);
		}

		Environment.Exit(0);
	}

	private void DisplayAll()
	{
		foreach (var gameItem in CurrMap.Items.Where(gi => gi is not null && gi.IsExist))
			ConsolePresents.Display(gameItem);
		ConsolePresents.DisplayGameInfo(CurrMap.GameInfo);
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
}
