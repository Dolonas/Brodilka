﻿using System.Collections.Generic;
using System.Linq;
using Brodilka.GameItems;
using Brodilka.GameItems.Bonuses;
using Brodilka.GameItems.Obstacles;
using Brodilka.GameItems.Units;
using Brodilka.GameItems.Units.Enemies;

namespace Brodilka;

internal class Map
{
	private readonly int _height;
	private readonly int _width;

	internal Map(GameItem[,] field)
	{
		Items = new List<GameItem>();
		if (field.GetLength(0) > 160 || field.GetLength(1) > 80)
			Field = new GameItem[3, 3];
		else
			Field = field;

		SortItems();
		Width = Field.GetLength(0);
		Height = Field.GetLength(1);
	}

	internal Player CurrPlayer { get; set; }
	internal List<GameItem> Items { get; set; }
	internal List<Unit> Units { get; set; }
	internal List<Enemy> Enemies { get; set; }
	internal List<Obstacle> Snags { get; set; }

	internal List<Bonus> Bonuses { get; set; }
	//internal List<NextLevelZone> NextLevelZones { get; set; }

	internal GameItem[,] Field { get; set; }

	internal int Width
	{
		get => _width;
		private init => _width = value is > 30 and < 160 ? value : 60;
	}

	internal int Height
	{
		get => _height;
		private init => _height = value is > 30 and < 160 ? value : 60;
	}

	internal void CalculateMoves()
	{
		foreach (var enemy in Enemies.Where(enemy => enemy.SpeedCounter++ % (20 - enemy.Speed) == 0))
		{
			enemy.Pos = enemy.Move(SolveCollisions(enemy, enemy.GetEnemyDirection(CurrPlayer.Pos)));
			if (enemy.UnitStatus == UnitStatus.Attack)
				enemy.ToDamage(CurrPlayer);
		}
	}

	private Command SolveCollisions(Unit unit, Command command)
	{
		var nextPos = unit.Move(command);
		if (nextPos.XPos < 0 ||
		    nextPos.YPos < 0 ||
		    nextPos.XPos > Width - 1 ||
		    nextPos.YPos > Height - 1)
			return Command.Stop;
		var nextItem = Field[nextPos.XPos, nextPos.YPos];

		if (nextItem is not null && nextItem.IsItBlock) return Command.Stop;

		return command;
	}

	internal void SolvePlayerCollisions(Point nextPos)
	{
		var nextItem = Field[nextPos.XPos, nextPos.YPos];
		if (nextPos.XPos < 0 ||
		    nextPos.YPos < 0 ||
		    nextPos.XPos > Width - 1 ||
		    nextPos.YPos > Height - 1)
			return;
		if (nextItem == null)
			CurrPlayer.Pos = nextPos;
		else if (nextItem.IsExist && !nextItem.IsItBlock && CurrPlayer.SpeedCounter++ % (20 - CurrPlayer.Speed) != 0)
			CurrPlayer.Pos = nextPos;
	}

	internal List<Point> DoPlayerAttack()
	{
		var diedEnemeysPos = new List<Point>();
		CurrPlayer.UnitStatus = UnitStatus.Attack;
		var surroundedEnemies = GetSurroundedEnemies();
		foreach (var enemy in surroundedEnemies)
		{
			CurrPlayer.ToDamage(enemy);
			if (enemy.Health >= 1) continue;
			diedEnemeysPos.Add(enemy.Pos);
			Field[enemy.Pos.XPos, enemy.Pos.YPos] = null;
			SortItems();
		}

		return diedEnemeysPos;
	}

	internal GameItem GetNextItemOnPlayerWay(Command command)
	{
		var nextPos = CurrPlayer.Move(command);
		var nextItem = Field[nextPos.XPos, nextPos.YPos];
		return nextItem;
	}

	internal void SyncItemsOnField()
	{
		Field = new GameItem[Width, Height];
		foreach (var gameItem in Items) Field[gameItem.Pos.XPos, gameItem.Pos.YPos] = gameItem;
	}

	private void SortItems()
	{
		Items = new List<GameItem>();
		for (var y = 0; y < Field.GetLength(1); y++)
		for (var x = 0; x < Field.GetLength(0); x++)
			if (Field[x, y] is not null && (Field[x, y].IsExist || Field[x, y] is NextLevelZone))
				Items.Add(Field[x, y]);
		CurrPlayer = (Player)Items.FirstOrDefault(x => x is Player);

		Units = Items.OfType<Unit>().ToList();
		Enemies = Items.OfType<Enemy>().ToList();
		Snags = Items.OfType<Obstacle>().ToList();
		Bonuses = Items.OfType<Bonus>().ToList();
	}

	private IEnumerable<Enemy> GetSurroundedEnemies()
	{
		var surroundedEnemies = new List<Enemy>();
		var pos = CurrPlayer.Pos;
		if (Field[pos.XPos - 1, pos.YPos - 1] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos - 1, pos.YPos - 1] as Enemy);
		if (Field[pos.XPos, pos.YPos - 1] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos, pos.YPos - 1] as Enemy);
		if (Field[pos.XPos + 1, pos.YPos - 1] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos + 1, pos.YPos - 1] as Enemy);
		if (Field[pos.XPos + 1, pos.YPos] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos + 1, pos.YPos] as Enemy);
		if (Field[pos.XPos + 1, pos.YPos + 1] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos + 1, pos.YPos + 1] as Enemy);
		if (Field[pos.XPos, pos.YPos + 1] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos, pos.YPos + 1] as Enemy);
		if (Field[pos.XPos - 1, pos.YPos + 1] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos - 1, pos.YPos + 1] as Enemy);
		if (Field[pos.XPos - 1, pos.YPos] is Enemy)
			surroundedEnemies.Add(Field[pos.XPos - 1, pos.YPos] as Enemy);

		return surroundedEnemies;
	}
}
