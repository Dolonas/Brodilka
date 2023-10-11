using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Brodilka.GameItems;
using Brodilka.GameItems.Bonuses;
using Brodilka.GameItems.Units;
using Brodilka.Interfaces;
using Brodilka.Utilits;

namespace Brodilka;

public enum Command
{
	Left, Up, Right, Down, LeftUp, LeftDown, RightUp, RightDown, Attack1, Stop, Redraw, Escape, Non
}

public enum ItemColor
{
	White, Black, Blue, Cyan, Gray, Green, Magenta, Red, Yellow, DarkBlue, DarkCyan, DarkGray, DarkGreen, DarkMagenta,
	DarkRed, DarkYellow
}

internal class GameProcessor
{
	private const string MapsDirectory = "../../../Data/Maps";
	private int _mapIndex;

	internal GameProcessor()
	{
		MapList = new List<Map>();
		var gameItemsEnumerable = MapData.ReadMapAsync(MapsDirectory)?.Result;
		if (gameItemsEnumerable != null)
		{
			var gameItemList = new List<GameItem[,]>(gameItemsEnumerable);
			foreach (var item in gameItemList) MapList?.Add(new Map(item));
		}

		if (MapList != null) CurrMap = MapList[_mapIndex];
		if (CurrMap != null) ConsolePresents = new ConsolePresentation(CurrMap.Width + 2, CurrMap.Height + 3);
		InitializeGameInfo();
	}

	private IDisplayable ConsolePresents { get; }
	private List<Map> MapList { get; }
	private Map CurrMap { get; set; }
	private GameInfoList InfoList { get; set; }

	internal void Run()
	{
		DisplayAll();
		var kbResponse = Command.Non;
		if (Console.KeyAvailable)
			kbResponse = GetKeyboardReceive();
		while (kbResponse != Command.Escape)
		{
			var makeSound = ConsolePresents.MakeSound;
			CurrMap.CalculateMoves();
			InfoList.List[3] = new GameInfo(CurrMap.CurrPlayer.Health.ToString(), ItemColor.White);
			ConsolePresents.DisplayGameInfo(InfoList);
			if (CurrMap.CurrPlayer.Health < 1) ConsolePresents.ShowGameOverScreen();

			kbResponse = GetKeyboardReceive();
			if (kbResponse == Command.Attack1)
			{
				var diedEnemiesPositions = CurrMap.DoPlayerAttack();
				foreach (var bodyPos in diedEnemiesPositions)
					ConsolePresents.Display(new NextLevelZone(bodyPos) { IsExist = false });
			}
			else
			{
				CurrMap.CurrPlayer.UnitStatus = UnitStatus.Patrol;
			}

			var nextPos = CurrMap.CurrPlayer.Move(kbResponse);
			var nextItem = CurrMap.GetNextItemOnPlayerWay(kbResponse);
			switch (nextItem)
			{
				case NextLevelZone:
					GetNextLevel();
					continue;
				case Bonus bonus:
					if (!bonus.IsExist) break;
					new Thread(() => makeSound(635, 50)).Start();
					CurrMap.CurrPlayer.Health += bonus.HealthUpForPlayer;
					CurrMap.CurrPlayer.Speed += CurrMap.CurrPlayer.Speed + bonus.SpeedUpForPlayer <= 20
						? bonus.SpeedUpForPlayer
						: 0;
					CurrMap.CurrPlayer.Pos = bonus.Pos;
					bonus.IsExist = false;
					break;
			}

			if (kbResponse != Command.Non)
				CurrMap.SolvePlayerCollisions(nextPos);
			DisplayAll();
			Thread.Sleep(50);
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
			ConsoleKey.A => Command.Attack1,
			_ => cki.Key == ConsoleKey.Escape ? Command.Escape : Command.Stop
		};
	}

	private void GetNextLevel()
	{
		if (_mapIndex == MapList.Count - 1)
		{
			ConsolePresents.GoToWinScreen();
			Thread.Sleep(6000);
			Console.ReadKey();
			Environment.Exit(0);
			return;
		}

		CurrMap = new Map(MapList[++_mapIndex].Field);
		CurrMap.CurrPlayer.PreviousPosition = CurrMap.CurrPlayer.Pos;
		ConsolePresents.Redraw();
		ConsolePresents.DisplayMap(CurrMap);
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
