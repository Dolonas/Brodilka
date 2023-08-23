using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Timers;
using Brodilka.Interfaces;
using Brodilka.Snags;
using Brodilka.Units;
using Brodilka.Units.Enemies;
using Brodilka.Bonuses;
using Brodilka.Utilits;
using Timer = System.Timers.Timer;

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

[DataContract]
internal class GameProcessor
{
	//private static Timer timer;
	//private Command _currentCommand = Command.Stop;
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

		CurrentMap = new Map(110, 40);
		var itemData = new ItemsData(CurrentMap);
		itemData.WriteJson("json1.json");
		Items = itemData.Items;
		SortItems();
		ConsolePresents = new ConsolePresentation(CurrentMap.XSize, CurrentMap.YSize);
		// timer = new Timer();
		// TimerStart();
	}

	// private void TimerStart()
	// {
	// 	timer.Interval = 200;
	// 	timer.Start();
	// 	timer.AutoReset = true;
	// 	timer.Enabled = true;
	// 	timer.Elapsed += OnTimeEvent;
	// }
	internal void Run()
	{
		DisplayAll();
		ConsoleKeyInfo cki =  default;
		var receive = Command.Non;
		if (!Console.KeyAvailable)
			receive = GetKeyboardReceive();

		while (receive != Command.Escape)
		{
			DisplayAll();
			foreach (var enemy in Enemies)
			{
				enemy.Move();
			}
			DisplayAll();
			receive = GetKeyboardReceive();
			if (receive == Command.Redraw)
			{
				ConsolePresents.Redraw();
				DisplayAll();
			}
			CurrentPlayer.CurrentPosition = CurrentPlayer.Move(SolveCollisions(receive));
			DisplayAll();
			Thread.Sleep(100);
		}
		Environment.Exit(0);
	}

	// private void OnTimeEvent(object source, ElapsedEventArgs e)
	// {
	// 	foreach (var enemy in Enemies)
	// 	{
	// 		enemy.Move();
	// 	}
	// 	DisplayAll();
	// }


	private void DisplayAll()
	{
		foreach (var gameItem in Items.Where(gi => gi is not null && gi.IsExist))
		{
			ConsolePresents.Display(gameItem);
		}
	}

	private Command GetKeyboardReceive()
	{
		ConsoleKeyInfo cki =  default;
		if (!Console.KeyAvailable)
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

	private Command SolveCollisions(Command command)
	{
		var nextPosition = CurrentPlayer.Move(command);
		foreach (var item in Items.Where(item => item.IsExist &&
		                                         item.CurrentPosition.XPosition == nextPosition.XPosition &&
		                                         item.CurrentPosition.YPosition == nextPosition.YPosition))
		{
			switch (item.Simbol)
			{
				case 't':
					return Command.Stop;
				case 'o':
					return Command.Stop;
				case 'a':
					new Thread(() => ConsolePresents.MakeSound(659, 300)).Start();
					RemoveItem(item);
					return command;
				case 'y':
					new Thread(() => ConsolePresents.MakeSound(659, 300)).Start();
					RemoveItem(item);
					return command;
				default:
					return command;
			}
		}

		return command;
	}

	private void RemoveItem(GameItem item)
	{
		item.IsExist = false;
		DisplayAll();
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
