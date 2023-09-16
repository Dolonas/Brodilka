using System.Collections.Generic;
using System.Linq;
using Brodilka.GameItems.Bonuses;
using Brodilka.GameItems.Obstacles;
using Brodilka.GameItems.Units;
using Brodilka.GameItems.Units.Enemies;

namespace Brodilka;

public class Map
{
	private readonly int _mapWidth;
	private readonly int _mapHeight;

	internal Player CurrPlayer { get; set; }
	internal List<GameItem> Items { get; set; }
	internal List<Unit> Units { get; set; }
	internal List<Enemy> Enemies { get; set; }
	internal List<Obstacle> Snags { get; set; }
	internal List<Bonus> Bonuses { get; set; }


	public GameItem[,] Field { get; set; }

	public int MapWidth
	{
		get => _mapWidth;
		private init => _mapWidth = value is > 30 and < 160 ? value : 60;
	}

	public int MapHeight
	{
		get => _mapHeight;
		private init => _mapHeight = value is > 30 and < 160 ? value : 60;
	}

	public Map(GameItem[,] field)
	{
		Items = new List<GameItem>();
		if (field.GetLength(0) > 160 || field.GetLength(1) > 80)
			Field = new GameItem[3, 3];
		else
		{
			Field = field;
			SortItems(Field);
		}
		MapWidth = Field.GetLength(0)+2;
		MapHeight = Field.GetLength(1)+2;

	}

	public void SyncItemsOnField()
	{
		Field = new GameItem[MapWidth, MapHeight];
		foreach (var gameItem in Items)
		{
			Field[gameItem.CurrentPos.XPos, gameItem.CurrentPos.YPos] = gameItem;
		}
	}

	private void SortItems(GameItem[,] field)
	{
		for (var y = 0; y < field.GetLength(1); y++)
		{
			for (var x = 0; x < field.GetLength(0); x++)
			{
				if (field[x, y] is not null && field[x, y].IsExist)
					Items.Add(field[x, y]);
			}
		}
		CurrPlayer = (Player)Items.FirstOrDefault(x => x is Player);

		Units = Items.OfType<Unit>().ToList();
		Enemies = Items.OfType<Enemy>().ToList();
		Snags = Items.OfType<Obstacle>().ToList();
		Bonuses = Items.OfType<Bonus>().ToList();
	}


}
