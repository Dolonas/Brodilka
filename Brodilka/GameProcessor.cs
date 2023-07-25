using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Autofac;
using Brodilka.Snags;
using Brodilka.Units;

namespace Brodilka
{
    internal class GameProcessor
    {
        private IDisplayble ConsolePresents { get; set; }
        private Player CurrentPlayer { get; set; }
        private List<GameItem> Items { get; set; }
        private List<Unit> Units { get; set; }
        private List<Enemy> Enemies { get; set; }
        private List<Snag> Snags { get; set; }
        private List<Bonus> Bonuses { get; set; }

        private Map CurrentMap { get; set; }

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
                CurrentPlayer.Move(cki.Key);
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
            CurrentPlayer = (Player)Items.FirstOrDefault(x => x is Player);

            Units = Items.OfType<Unit>().ToList();
            Enemies = Items.OfType<Enemy>().ToList();
            Snags = Items.OfType<Snag>().ToList();
            Bonuses = Items.OfType<Bonus>().ToList();
        }
        
    }

}
