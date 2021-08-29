using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Brodilka
{
    internal class GameProcessor
    {
        internal Player currPlayer { get; set; }
        internal List<GameItem> Items { get; set; }
        internal List<Unit> Units { get; set; }
        internal List<Enemy> Enemies { get; set; }
        internal List<Snag> Snags { get; set; }
        internal List<Bonus> Bonuses { get; set; }
        internal Map CurrMap { get; set; }

        internal GameProcessor()
        {
            CurrMap = new Map(60, 40);
            Items.Add(new Player(new Pos(2,2), CurrMap, "Luidgi"));
            Items.Add(new Wolf(new Pos(15, 18), CurrMap));
            Items.Add(new Wolf(new Pos(48, 3), CurrMap));
            Items.Add(new Bear(new Pos(18, 17), CurrMap));
            Items.Add(new Bear(new Pos(48, 6), CurrMap));
            Items.Add(new Cherry(new Pos(8, 12), CurrMap));
            Items.Add(new Cherry(new Pos(38, 6), CurrMap));
            Items.Add(new Apple(new Pos(48, 14), CurrMap));
            Items.Add(new Apple(new Pos(23, 32), CurrMap));
            Items.Add(new Tree(new Pos(21, 16), CurrMap));
            Items.Add(new Tree(new Pos(8, 12), CurrMap));
            Items.Add(new Stone(new Pos(21, 16), CurrMap));
            Items.Add(new Stone(new Pos(8, 12), CurrMap));
            SortItems();

        }

        internal void Run()
        {
            foreach (var unit in Units)
            {
                unit.Move();
            }
        }

        internal void SortItems()
        {
            currPlayer = (Player)Items.FirstOrDefault(x => x is Player);

            Units = Items.OfType<Unit>().ToList();
            Enemies = Items.OfType<Enemy>().ToList();
            Snags = Items.OfType<Snag>().ToList();
            Bonuses = Items.OfType<Bonus>().ToList();
        }
    }



}
