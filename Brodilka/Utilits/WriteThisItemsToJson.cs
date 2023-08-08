using System.Collections.Generic;
using Brodilka.Snags;
using Brodilka.Units;
using Brodilka.Units.Enemies;
using JsonIO;

namespace Brodilka.Utilits;

public class WriteThisItemsToJson
{

	public WriteThisItemsToJson()
	{
		Items = new List<GameItem>();
		Items.Add(new Player(new Point(15, 18), CurrentMap, $"Luidgy"));
		Items.Add(new Wolf(new Point(15, 18), CurrentMap));
		Items.Add(new Wolf(new Point(48, 13), CurrentMap));
		Items.Add(new Bear(new Point(18, 17), CurrentMap));
		Items.Add(new Bear(new Point(48, 16), CurrentMap));
		Items.Add(new Cherry(new Point(8, 12), CurrentMap));
		Items.Add(new Cherry(new Point(38, 24), CurrentMap));
		Items.Add(new Apple(new Point(48, 14), CurrentMap));
		Items.Add(new Apple(new Point(23, 32), CurrentMap));
		Items.Add(new Tree(new Point(21, 16), CurrentMap));
		Items.Add(new Tree(new Point(8, 12), CurrentMap));
		Items.Add(new Stone(new Point(21, 16), CurrentMap));
		Items.Add(new Stone(new Point(8, 12), CurrentMap));

		JsonReadWrite.WriteJson("json1", Items);
	}

	public Map CurrentMap { get; set; }

	public List<GameItem> Items { get; set; }
}
