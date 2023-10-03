#nullable enable
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Brodilka.GameItems;
using Brodilka.GameItems.Bonuses;
using Brodilka.GameItems.Obstacles;
using Brodilka.GameItems.Units;
using Brodilka.GameItems.Units.Enemies;

namespace Brodilka.Utilits;

public class MapData
{
	public MapData(List<GameItem[,]> fieldList) => FieldList = fieldList;

	private List<GameItem[,]> FieldList { get; }


	public static async Task<List<GameItem[,]>>? ReadMapAsync(string mapsDirectory)
	{
		//string textMap;
		var mapList = new List<GameItem[,]>();
		var pathes = Directory.GetFiles(mapsDirectory);
		foreach (var fileName in pathes)
		{
			string textMap;
			using (var reader = new StreamReader(fileName, Encoding.Default))
			{
				textMap = await reader.ReadToEndAsync().ConfigureAwait(false);
			}
			mapList.Add(DecodeMap(textMap)); ;
		}

		return mapList;


	}

	private static GameItem[,] DecodeMap(string textMap)
	{
		var lines = textMap.Split('\n');
		var mapWidth = lines.Max(s => s.Length);
		var field = new GameItem[mapWidth, lines.Length];
		var isItFirstPlayer = true;
		for (var y = 0; y < lines.Length; y++)
		{
			if (lines[y].Length == 0)
				continue;
			for (var x = 0; x < lines[y].Length; x++)
				switch (lines[y][x])
				{
					case 'P':
						if (isItFirstPlayer)
						{
							field[x, y] = new Player("Luidgy", new Point(x, y));
							isItFirstPlayer = false;
						}

						break;
					case 'B':
						field[x, y] = new Bear(new Point(x, y));
						break;
					case 'w':
						field[x, y] = new Wolf(new Point(x, y));
						break;
					case 'a':
						field[x, y] = new Apple(new Point(x, y));
						break;
					case 'y':
						field[x, y] = new Cherry(new Point(x, y));
						break;
					case 't':
						field[x, y] = new Tree(new Point(x, y));
						break;
					case 'o':
						field[x, y] = new Stone(new Point(x, y));
						break;
					case 'X':
						field[x, y] = new NextLevelZone(new Point(x, y));
						break;
				}
		}

		return field;
	}
}
