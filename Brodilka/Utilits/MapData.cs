﻿#nullable enable
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

	public MapData(Map currentMap)
	{
		CurrentMap = currentMap;
		var xSize = CurrentMap.XSize;
		var ySize = CurrentMap.YSize;
	}

	public async Task<List<GameItem>>? ReadMapAsync(string filePath)
	{
		string textMap;
		using (var reader = new StreamReader(filePath, System.Text.Encoding.Default))
		{
			textMap = await reader.ReadToEndAsync().ConfigureAwait(false);
		}
		return  DecodeMap(textMap);
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

		var itemsDictionaryFull = new Dictionary<int, Dictionary<int, char>>();
		for (var y = 0; y < lines.Length; y++)
		{
			if (lines[y].Length == 0)
				continue;
			var itemsDictionary = lines[y]
				.Select((v, j) => new { Index = j, Value = v })
				.Where(p => char.IsLetter(p.Value))
				.ToDictionary(s => s.Index, s => s.Value);
			if (itemsDictionary.Count > 0)
				itemsDictionaryFull.Add(y, itemsDictionary);
		}

		foreach (var line in itemsDictionaryFull)
		{
			foreach (var item in line.Value)
			{
				switch (item.Value)
				{
					case 'P':
						gameItems.Add(new Player($"One",new Point(item.Key, line.Key), xSize, ySize ));
						break;
					case 'B':
						gameItems.Add(new Bear(new Point(item.Key, line.Key), xSize, ySize ));
						break;
					case 'w':
						gameItems.Add(new Wolf(new Point(item.Key, line.Key), xSize, ySize ));
						break;
					case 'a':
						gameItems.Add(new Apple(new Point(item.Key, line.Key), xSize, ySize ));
						break;
					case 'y':
						gameItems.Add(new Cherry(new Point(item.Key, line.Key), xSize, ySize ));
						break;
					case 't':
						gameItems.Add(new Tree(new Point(item.Key, line.Key), xSize, ySize ));
						break;
					case 'o':
						gameItems.Add(new Stone(new Point(item.Key, line.Key), xSize, ySize ));
						break;
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
