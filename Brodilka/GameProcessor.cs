using System;
using System.Linq;
using System.Threading;
using Brodilka.Interfaces;
using Brodilka.GameItems.Bonuses;
using Brodilka.GameItems.Units;
using Brodilka.Utilits;

namespace Brodilka;

internal enum Command { Left, Up, Right, Down, Attack1, Stop, Redraw, Escape, Non }

internal class GameProcessor
{
	private const string FilePass = "../../../Data/Maps/map03.dat";
	private IDisplayable ConsolePresents { get; set; }

	private Map CurrMap { get; set; }

	internal GameProcessor()
	{
		CurrMap = new Map(MapData.ReadMapAsync(FilePass)?.Result);
		//CurrMap.SyncItemsOnField(Items);
		//SortItems();
		ConsolePresents = new ConsolePresentation(CurrMap.MapWidth, CurrMap.MapHeight);
	}

	internal void Run()
	{
		DisplayAll();
		var receive = Command.Non;
		if (Console.KeyAvailable)
			receive = GetKeyboardReceive();

		while (receive != Command.Escape)
		{
			foreach (var enemy in CurrMap.Enemies)
			{
				enemy.CurrentPos = enemy.Move(SolveCollisions(enemy, enemy.GetEnemyDirection()));
			}
			receive = GetKeyboardReceive();
			if (receive == Command.Redraw)
			{
				ConsolePresents.DisplayMap(CurrMap);
			}
			CurrMap.CurrPlayer.CurrentPos = CurrMap.CurrPlayer.Move(SolveCollisions(CurrMap.CurrPlayer, receive));
			DisplayAll();
			Thread.Sleep(100);
		}
		Environment.Exit(0);
	}

	private void DisplayAll()
	{
		foreach (var gameItem in CurrMap.Items.Where(gi => gi is not null && gi.IsExist))
		{
			ConsolePresents.Display(gameItem);
		}
		CurrMap.SyncItemsOnField();
	}

	private Command GetKeyboardReceive()
	{
		ConsoleKeyInfo cki =  default;
		if (Console.KeyAvailable)
			cki = Console.ReadKey();
		else
			return Command.Non;

		return (cki.Key switch
		{
			ConsoleKey.RightArrow => Command.Right,
			ConsoleKey.LeftArrow => Command.Left,
			ConsoleKey.UpArrow => Command.Up,
			ConsoleKey.DownArrow => Command.Down,
			ConsoleKey.Delete => Command.Redraw,
			_ => cki.Key == ConsoleKey.Escape ? Command.Escape : Command.Stop
		});
	}

	private Command SolveCollisions(Unit unit, Command command)
	{
		var nextPos = unit.Move(command);
		if (nextPos.XPos < 0 ||
		    nextPos.YPos < 0 ||
		    nextPos.XPos > CurrMap.MapWidth - 1 ||
		    nextPos.YPos > CurrMap.MapHeight - 1)
				return Command.Stop;
		var nextItem = CurrMap.Field[nextPos.XPos, nextPos.YPos];
		if (unit is Player && nextItem is Bonus && nextItem.IsExist)
		{
			new Thread(() => ConsolePresents.MakeSound(659, 300)).Start();
			nextItem.IsExist = false;
			DisplayAll();
			return command;
		}
		if(nextItem is not null && nextItem.IsItBlock)
		{
			return Command.Stop;
		}

		return command;
	}


}
