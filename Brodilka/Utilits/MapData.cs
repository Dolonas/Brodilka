#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Brodilka.Bonuses;
using Brodilka.Snags;
using Brodilka.Units;
using Brodilka.Units.Enemies;

namespace Brodilka.Utilits;

public class MapData
{
	private Map CurrentMap { get; }
	public List<GameItem> Items { get; }

	public MapData(Map currentMap)
	{
		CurrentMap = currentMap;
		var xSize = CurrentMap.XSize;
		var ySize = CurrentMap.YSize;
		// Items = new List<GameItem>
		// {
		// 		new Player($"Luidgy",new Point(15, 18), xSize, ySize ),
		// 		new Wolf(new Point(15, 18), xSize, ySize),
		// 		new Wolf(new Point(48, 13), xSize, ySize),
		// 		new Bear(new Point(18, 17), xSize, ySize),
		// 		new Bear(new Point(48, 16), xSize, ySize),
		// 		new Cherry(new Point(8, 12), xSize, ySize),
		// 		new Cherry(new Point(38, 24), xSize, ySize),
		// 		new Apple(new Point(48, 14), xSize, ySize),
		// 		new Apple(new Point(23, 32), xSize, ySize),
		// 		new Tree(new Point(21, 16), xSize, ySize),
		// 		new Tree(new Point(8, 12), xSize, ySize),
		// 		new Stone(new Point(81, 36), xSize, ySize),
		// 		new Stone(new Point(15, 35), xSize, ySize)
		// 	};
	}

	public async Task<List<GameItem>>? ReadMapAsync(string filePath)
	{
		string text;
		using (var reader = new StreamReader(filePath, System.Text.Encoding.Default))
		{
			text = await reader.ReadToEndAsync().ConfigureAwait(false);
		}
		return  DecodeMap(text);
	}

	private List<GameItem> DecodeMap(string textMap)
	{
		var gameItems = new List<GameItem>();
		var xSize = CurrentMap.XSize;
		var ySize = CurrentMap.YSize;
		var lines = textMap.Split('\n');
		for(var i = 0; i < lines.Length; i++)
		{
			lines[i] +=  new string(' ', CurrentMap.XSize - lines[i].Length);
		}

		for (var y = 0; y < lines.Length; y++)
		{
			if (lines[y].Select((v, j) => new { Index = j, Value = v }).FirstOrDefault(p => p.Value == 'P') is null)
				continue;
			{
				var playerXPos = lines[y].Select((v, j) => new { Index = j, Value = v })
					.Where(p => p.Value == 'P')
					.Select(p => p.Index)
					.FirstOrDefault();
				Items.Add(new Player("Player", new Point(playerXPos, y), xSize, ySize));
			}
			if (lines[y].Select((v, j) => new { Index = j, Value = v }).FirstOrDefault(p => p.Value == 'B') is null)
				continue;
			{
				var bearXPos = lines[y].Select((v, j) => new { Index = j, Value = v })
					.Where(p => p.Value == 'B')
					.Select(p => p.Index).ToList();
				foreach (var bearPos in bearXPos)
				{
					Items.Add(new Bear(new Point(bearPos, y), xSize, ySize));
				}
			}
			if (lines[y].Select((v, j) => new { Index = j, Value = v }).FirstOrDefault(p => p.Value == 'w') is null)
				continue;
			{
				var wolfXPos = lines[y].Select((v, j) => new { Index = j, Value = v })
					.Where(p => p.Value == 'w')
					.Select(p => p.Index).ToList();
				foreach (var wolfPos in wolfXPos)
				{
					Items.Add(new Wolf(new Point(wolfPos, y), xSize, ySize));
				}
			}
		}
		return gameItems;
	}
	// public object? ReadJson(string filePath)
	// {
	// 	using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
	// 	return  JsonSerializer.Deserialize<List<GameItem>>(fs);
	// }
	//
	// public void WriteJson(string filePath)
	// {
	// 	using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
	// 	var options = new JsonSerializerOptions { WriteIndented = true };
	// 	JsonSerializer.Serialize<List<GameItem>>(fs, Items, options);
	// }
}
