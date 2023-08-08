using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Brodilka.Interfaces;
using Brodilka.Snags;
using Brodilka.Units;
using Brodilka.Units.Enemies;
using System.Text.Json;
using Brodilka.Utilits;
using JsonIO;

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

internal enum Command { Left, Up, Right, Down, Attack1, Stop, Escape }

internal class GameProcessor
{
	private static Timer _timer;
	private Command currentCommand = Command.Stop;
	private IDisplayable ConsolePresents { get; set; }
	private Player CurrentPlayer { get; set; }
	private List<GameItem> Items { get; set; }
	private List<Unit> Units { get; set; }
	private List<Enemy> Enemies { get; set; }
	private List<Snag> Snags { get; set; }
	private List<Bonus> Bonuses { get; set; }

	private Map CurrentMap { get; set; }

	internal GameProcessor()
	{
		_timer = new Timer();
		Items = new List<GameItem>();
		CurrentMap = new Map(110, 40);
		var temp = new WriteThisItemsToJson();
		Items = (List<GameItem>)JsonReadWrite.ReadJson("json1");
		SortItems();

		ConsolePresents = new ConsolePresentation(CurrentMap.XSize, CurrentMap.YSize);
	}

	internal void Run()
	{
		_timer.Interval = 100;
		_timer.Start();
		while (_timer.Enabled)
		{
			currentCommand = RequestKeyboard();
			if (currentCommand == Command.Escape)
				Environment.Exit(0);
			Update();
		}
	}

	private void Update( )
	{
		foreach (var item in Items)
		{
			item.Update();
		}
		DisplayAll();
	}

	// private void Callback(object param)
	// {
	// 	EnemiesMove();
	// 	CurrentPlayer.Move(currentCommand);
	// 	DisplayAll();
	// }


	internal void EnemiesMove()
	{
		foreach (var enemy in Enemies) enemy.Move();
	}

	private void DisplayAll()
	{
		foreach (var unit in Units)
		{
			if (unit is not null)
				ConsolePresents.Display(unit);
		}

	}

	private Command RequestKeyboard()
	{
		var cki = Console.ReadKey();
		return cki.Key switch
		{
			ConsoleKey.RightArrow => Command.Right,
			ConsoleKey.LeftArrow => Command.Left,
			ConsoleKey.UpArrow => Command.Up,
			ConsoleKey.DownArrow => Command.Down,
			_ => cki.Key == ConsoleKey.Escape ? Command.Escape : Command.Stop
		};
	}

	private void SortItems()
	{
		CurrentPlayer = (Player)Items.FirstOrDefault(x => x is Player);

		Units = Items.OfType<Unit>().ToList();
		Enemies = Items.OfType<Enemy>().ToList();
		Snags = Items.OfType<Snag>().ToList();
		Bonuses = Items.OfType<Bonus>().ToList();
	}
}
