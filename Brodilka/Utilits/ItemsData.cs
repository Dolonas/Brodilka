#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text.Json;
using Brodilka.Bonuses;
using Brodilka.Snags;
using Brodilka.Units;
using Brodilka.Units.Enemies;

namespace Brodilka.Utilits;

public class ItemsData
{
	private Map CurrentMap { get; }
	public List<GameItem> Items { get; }

	public ItemsData(Map currentMap)
	{
		CurrentMap = currentMap;
		var xSize = CurrentMap.XSize;
		var ySize = CurrentMap.YSize;
		Items = new List<GameItem>
		{
				new Player($"Luidgy",new Point(15, 18), xSize, ySize ),
				new Wolf(new Point(15, 18), xSize, ySize),
				new Wolf(new Point(48, 13), xSize, ySize),
				new Bear(new Point(18, 17), xSize, ySize),
				new Bear(new Point(48, 16), xSize, ySize),
				new Cherry(new Point(8, 12), xSize, ySize),
				new Cherry(new Point(38, 24), xSize, ySize),
				new Apple(new Point(48, 14), xSize, ySize),
				new Apple(new Point(23, 32), xSize, ySize),
				new Tree(new Point(21, 16), xSize, ySize),
				new Tree(new Point(8, 12), xSize, ySize),
				new Stone(new Point(81, 36), xSize, ySize),
				new Stone(new Point(15, 35), xSize, ySize)
			};
	}

	// public object? ReadJson(string filePath)
	// {
	// 	using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
	// 	return  JsonSerializer.Deserialize<List<GameItem>>(fs);
	// }
	//
	public void WriteJson(string filePath)
	{
		using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
		var options = new JsonSerializerOptions { WriteIndented = true };
		JsonSerializer.Serialize<List<GameItem>>(fs, Items, options);
	}
}
