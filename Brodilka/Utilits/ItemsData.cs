#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Brodilka.Snags;
using Brodilka.Units;
using Brodilka.Units.Enemies;

namespace Brodilka.Utilits;

public class ItemsData
{
	private static Map CurrentMap { get; set; }
	private static List<GameItem> Items { get; set; }

	public ItemsData(Map currentMap)
	{
		CurrentMap = currentMap;
		Items = new List<GameItem>
		{
				new Player(new Point(15, 18), CurrentMap, $"Luidgy"),
				new Wolf(new Point(15, 18), CurrentMap),
				new Wolf(new Point(48, 13), CurrentMap),
				new Bear(new Point(18, 17), CurrentMap),
				new Bear(new Point(48, 16), CurrentMap),
				new Cherry(new Point(8, 12), CurrentMap),
				new Cherry(new Point(38, 24), CurrentMap),
				new Apple(new Point(48, 14), CurrentMap),
				new Apple(new Point(23, 32), CurrentMap),
				new Tree(new Point(21, 16), CurrentMap),
				new Tree(new Point(8, 12), CurrentMap),
				new Stone(new Point(21, 16), CurrentMap),
				new Stone(new Point(8, 12), CurrentMap)
			};
	}

	public object? ReadJson(string filePath)
	{
		using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
		return  JsonSerializer.Deserialize<List<GameItem>>(fs);
	}

	public void WriteJson(string filePath)
	{
		using var fs = new FileStream(filePath, FileMode.OpenOrCreate);

		JsonSerializer.Serialize(fs, Items);
	}


}
