using System.Collections.Generic;

namespace Brodilka;

public class Map
{
	private readonly int _mapWidth;
	private readonly int _mapHeight;

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

	public Map(int mapWidth, int mapHeight)
	{
		MapWidth = mapWidth;
		MapHeight = mapHeight;
		Field = new GameItem[MapWidth, MapHeight];
	}

	public void SyncItemsOnField(List<GameItem> gameItemsList)
	{
		foreach (var gameItem in gameItemsList)
		{
			Field[gameItem.CurrentPos.XPos, gameItem.CurrentPos.YPos] = gameItem;
		}
	}
}
