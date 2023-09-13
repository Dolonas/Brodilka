﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Brodilka.Interfaces;
using Brodilka.GameItems.Bonuses;
using Brodilka.GameItems.Obstacles;
using Brodilka.GameItems.Units;
using Brodilka.GameItems.Units.Enemies;
using Brodilka.Utilits;

/*
 * Как работает GameProcessor?
 * Шагом обновления игры и игрового поля является "тик" таймера.
 * Каждый "тик" таймера надо пройтись по всем объектам и:
 * 1. передать им движение
 * 1.1. проверить есть ли на пути игровой элемент или граница карты
 * 1.2. если на пути Коряга остановить Игрока или Enemy
 * 1.3. если на пути бонус - Игрок встаёт на место бонуса, и получает очки преимущества в зависимости от типа бонуса. Бонус исчезает
 * 1.4. если на пути Enemy, то у Enemy активируется режим атаки и он пытается атаковать Игрока, а Игрок получает возможность атаковать Enemy нажимая на клавишу атаки
 * 1.5.
*/
namespace Brodilka;

internal enum Command { Left, Up, Right, Down, Attack1, Stop, Redraw, Escape, Non }

internal class GameProcessor
{
	private const string FilePass = "../../../Data/Maps/map03.dat";
	private IDisplayable ConsolePresents { get; set; }
	private Player CurrPlayer { get; set; }
	private List<GameItem> Items { get; set; }
	private List<Unit> Units { get; set; }
	private List<Enemy> Enemies { get; set; }
	private List<Obstacle> Snags { get; set; }
	private List<Bonus> Bonuses { get; set; }

	private Map CurrMap { get; set; }

	internal GameProcessor()
	{
		CurrMap = new Map(110, 40);
		var mapData = new MapData(CurrMap);
		Items = mapData.ReadMapAsync(FilePass)?.Result;
		CurrMap.SyncItemsOnField(Items);
		SortItems();
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
			foreach (var enemy in Enemies)
			{
				enemy.CurrentPos = enemy.Move(SolveCollisions(enemy, enemy.GetEnemyDirection()));
			}
			receive = GetKeyboardReceive();
			if (receive == Command.Redraw)
			{
				ConsolePresents.DisplayMap(CurrMap);
			}
			CurrPlayer.CurrentPos = CurrPlayer.Move(SolveCollisions(CurrPlayer, receive));
			DisplayAll();
			Thread.Sleep(100);
		}
		Environment.Exit(0);
	}

	private void DisplayAll()
	{
		foreach (var gameItem in Items.Where(gi => gi is not null && gi.IsExist))
		{
			ConsolePresents.Display(gameItem);
		}
		CurrMap.SyncItemsOnField(Items);
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
		var nextItem = CurrMap.Field[nextPos.XPos, nextPos.YPos];
		if (unit is Player && nextItem is Bonus && nextItem.IsExist)
		{
			new Thread(() => ConsolePresents.MakeSound(659, 300)).Start();
			nextItem.IsExist = false;
			DisplayAll();
			return command;
		}
		else if(nextItem is not null && nextItem.IsItBlock)
		{
			return Command.Stop;
		}

		return command;
	}

	private void SortItems()
	{
		CurrPlayer = (Player)Items.FirstOrDefault(x => x is Player);

		Units = Items.OfType<Unit>().ToList();
		Enemies = Items.OfType<Enemy>().ToList();
		Snags = Items.OfType<Obstacle>().ToList();
		Bonuses = Items.OfType<Bonus>().ToList();
	}
}
