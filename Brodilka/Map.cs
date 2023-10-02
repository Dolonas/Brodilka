using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Brodilka.GameItems;
using Brodilka.GameItems.Bonuses;
using Brodilka.GameItems.Obstacles;
using Brodilka.GameItems.Units;
using Brodilka.GameItems.Units.Enemies;

namespace Brodilka;

public class Map
{
	private readonly int _height;
	private readonly int _width;

	public Map(GameItem[,] field)
	{
		Items = new List<GameItem>();
		if (field.GetLength(0) > 160 || field.GetLength(1) > 80)
		{
			Field = new GameItem[3, 3];
		}
		else
		{
			Field = field;
		}
		SortItems(Field);
		Width = Field.GetLength(0) + 2;
		Height = Field.GetLength(1) + 4;
	}

	internal Player CurrPlayer { get; set; }
	internal List<GameItem> Items { get; set; }
	internal List<Unit> Units { get; set; }
	internal List<Enemy> Enemies { get; set; }
	internal List<Obstacle> Snags { get; set; }
	internal List<Bonus> Bonuses { get; set; }
	internal List<NextLevelZone> NextLevelZones { get; set; }

	public GameItem[,] Field { get; set; }
	public int Width
	{
		get => _width;
		private init => _width = value is > 30 and < 160 ? value : 60;
	}
	public int Height
	{
		get => _height;
		private init => _height = value is > 30 and < 160 ? value : 60;
	}

	public void CalculateMoves(Action<int, int> makeSound)
	{
		foreach (var enemy in Enemies)
			enemy.Pos = enemy.Move(SolveCollisions(enemy, enemy.GetEnemyDirection(CurrPlayer.Pos)));
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

	public bool SolvePlayerCollisions(Command command, Action<int, int> makeSound)
	{
		if (command == Command.Non)
			return false;
		var nextPos = CurrPlayer.Move(command);
		if (nextPos.XPos < 0 ||
		    nextPos.YPos < 0 ||
		    nextPos.XPos > Width - 1 ||
		    nextPos.YPos > Height - 1)
				return false;
		var nextItem = Field[nextPos.XPos, nextPos.YPos];
		if (nextItem is NextLevelZone)
			return true;
		if (nextItem is Bonus && nextItem.IsExist)
		{
			new Thread(() => makeSound(635, 50)).Start();
			nextItem.IsExist = false;
			CurrPlayer.Pos = CurrPlayer.Move(command);
			return false;
		}
		if (nextItem is not null && nextItem.IsItBlock)
			return false;
		CurrPlayer.Pos = CurrPlayer.Move(command);
		return false;
	}
	public void SyncItemsOnField()
	{
		Field = new GameItem[Width, Height];
		foreach (var gameItem in Items) Field[gameItem.Pos.XPos, gameItem.Pos.YPos] = gameItem;
	}

	private void SortItems(GameItem[,] field)
	{
		for (var y = 0; y < field.GetLength(1); y++)
		for (var x = 0; x < field.GetLength(0); x++)
			if (field[x, y] is not null && field[x, y].IsExist)
				Items.Add(field[x, y]);
		CurrPlayer = (Player)Items.FirstOrDefault(x => x is Player);

		Units = Items.OfType<Unit>().ToList();
		Enemies = Items.OfType<Enemy>().ToList();
		Snags = Items.OfType<Obstacle>().ToList();
		Bonuses = Items.OfType<Bonus>().ToList();
	}
}
