using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;

namespace Brodilka
{
    internal class GameProcessor
    {
        internal IDisplayble ConsolePresents { get; set; }
        internal Player currentPlayer { get; set; }
        internal List<GameItem> Items { get; set; }
        internal List<Unit> Units { get; set; }
        internal List<Enemy> Enemies { get; set; }
        internal List<Snag> Snags { get; set; }
        internal List<Bonus> Bonuses { get; set; }

        internal Map CurrentMap { get; set; }

        internal GameProcessor()
        {
            Items = new List<GameItem>();
            CurrentMap = new Map(60, 40);
            Items.Add(new Player(new Point(15, 18), CurrentMap, "Luidgy") as GameItem);
            Items.Add(new Wolf(new Point(15, 18), CurrentMap) as GameItem );
            Items.Add(new Wolf(new Point(48, 3), CurrentMap) as GameItem);
            Items.Add(new Bear(new Point(18, 17), CurrentMap) as GameItem);
            Items.Add(new Bear(new Point(48, 6), CurrentMap) as GameItem);
            Items.Add(new Cherry(new Point(8, 12), CurrentMap) as GameItem);
            Items.Add(new Cherry(new Point(38, 6), CurrentMap) as GameItem);
            Items.Add(new Apple(new Point(48, 14), CurrentMap) as GameItem);
            Items.Add(new Apple(new Point(23, 32), CurrentMap) as GameItem);
            Items.Add(new Tree(new Point(21, 16), CurrentMap) as GameItem);
            Items.Add(new Tree(new Point(8, 12), CurrentMap) as GameItem);
            Items.Add(new Stone(new Point(21, 16), CurrentMap) as GameItem);
            Items.Add(new Stone(new Point(8, 12), CurrentMap) as GameItem);
            SortItems();

            ConsolePresents = new ConsolePresentation(150, 120);

        }

        internal void Run()
        {
            ConsoleKeyInfo cki;
            do
            {
                cki = Console.ReadKey();
                currentPlayer.Move(cki.Key);
                foreach (var enemy in Enemies)
                {
                    enemy.Move();
                }

                foreach (var item in Items)
                {
                    ConsolePresents.Display(item);
                }
                Thread.Sleep(100);

            } while (cki.Key != ConsoleKey.Escape);

        }

        internal void SortItems()
        {
            currentPlayer = (Player)Items.FirstOrDefault(x => x is Player);

            Units = Items.OfType<Unit>().ToList();
            Enemies = Items.OfType<Enemy>().ToList();
            Snags = Items.OfType<Snag>().ToList();
            Bonuses = Items.OfType<Bonus>().ToList();
        }
        
    }

}
