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
		if (CurrMap != null) ConsolePresents = new ConsolePresentation(CurrMap.Width + 2, CurrMap.Height + 5);
		GameInfo = new List<GameInfoDict>();
		InitializeGameInfo();
	}

	private IDisplayable ConsolePresents { get; }
	private List<Map> MapList { get; }
	private Map CurrMap { get; set; }
	private List<GameInfoDict> GameInfo { get; set; }

	internal void Run()
	{
		DisplayAll();
		var kbResponse = Command.Non;
		if (Console.KeyAvailable)
			kbResponse = GetKeyboardReceive();
		while (kbResponse != Command.Escape)
		{
			CurrMap.CalculateMoves();
			GameInfo[0].InfoDict["Health"] = new GameInfo(CurrMap.CurrPlayer.Health.ToString(), ItemColor.White);
			ConsolePresents.DisplayGameInfo(GameInfo);
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
			GetPrices(nextItem);
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
		ConsolePresents.DisplayGameInfo(GameInfo);
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

	private void GetPrices(GameItem nextItem)
	{
		var makeSound = ConsolePresents.MakeSound;
		switch (nextItem)
		{
			case NextLevelZone:
				GetNextLevel();
				return;
			case Bonus bonus:
				if (!bonus.IsExist) break;
				new Thread(() => makeSound(635, 50)).Start();
				CurrMap.CurrPlayer.Health += bonus.HealthUpForPlayer;
				CurrMap.CurrPlayer.Speed += CurrMap.CurrPlayer.Speed + bonus.SpeedUpForPlayer <= 20
					? bonus.SpeedUpForPlayer
					: 0;
				CurrMap.CurrPlayer.Pos = bonus.Pos;
				GameInfo[1].InfoDict["Speed"] = new GameInfo((CurrMap.CurrPlayer.Speed - 10).ToString(), ItemColor.White);
				ConsolePresents.DisplayGameInfo(GameInfo);
				bonus.IsExist = false;
				break;
		}
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

		var infoLine1 = CurrMap.Field.GetLength(1) + 1;

		var infoDict1 = new GameInfoDict(infoLine1, 2);

		infoDict1.Add("playerNameTitle", new GameInfo("Player name:", ItemColor.Cyan));
		infoDict1.Add("playerName",new GameInfo(CurrMap.CurrPlayer.Name + " |", ItemColor.Yellow));
		infoDict1.Add("HealthTitle", new GameInfo("Health:", ItemColor.White));
		infoDict1.Add("Health", new GameInfo(CurrMap.CurrPlayer.Health.ToString(), ItemColor.White));
		infoDict1.Add("SpeedTitle", new GameInfo("Speed:", ItemColor.White));
		infoDict1.Add("Speed", new GameInfo((CurrMap.CurrPlayer.Speed - 10).ToString(), ItemColor.White));
		infoDict1.Add("Space", new GameInfo("      \n", ItemColor.White));

		var infoLine2 = infoLine1 + 1;
		var infoDict2 = new GameInfoDict(infoLine2, 2);
		infoDict2.Add("LegendTitle", new GameInfo("Legend:", ItemColor.White));
		infoDict2.Add("P", new GameInfo("P", ItemColor.Blue));
		infoDict2.Add("Player", new GameInfo("-player, ", ItemColor.DarkGray));
		infoDict2.Add("B", new GameInfo("B", ItemColor.DarkGreen));
		infoDict2.Add("bear", new GameInfo("-bear, ", ItemColor.DarkGray));
		infoDict2.Add("w", new GameInfo("w", ItemColor.Green));
		infoDict2.Add("wolf", new GameInfo("-wolf, ", ItemColor.DarkGray));
		infoDict2.Add("a", new GameInfo("a", ItemColor.Red));
		infoDict2.Add("apple", new GameInfo(" -apple, ", ItemColor.DarkGray));
		infoDict2.Add("у", new GameInfo("у", ItemColor.Red));
		infoDict2.Add("cherry", new GameInfo(" -cherry, ", ItemColor.DarkGray));
		infoDict2.Add("t", new GameInfo("t", ItemColor.Yellow));
		infoDict2.Add("tree", new GameInfo(" -tree, ", ItemColor.DarkGray));
		infoDict2.Add("o", new GameInfo("o", ItemColor.Yellow));
		infoDict2.Add("stone", new GameInfo(" -stone, ", ItemColor.DarkGray));

		var infoLine3 = infoLine2 + 1;
		var infoDict3 = new GameInfoDict(infoLine3, 2);

		infoDict3.Add("Legend2", new GameInfo("<-- left, --> right, ^ up, -down", ItemColor.DarkCyan));

		GameInfo.Add(infoDict1);
		GameInfo.Add(infoDict2);
		GameInfo.Add(infoDict3);
	}
}
