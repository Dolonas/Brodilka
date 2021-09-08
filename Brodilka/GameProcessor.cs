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

        internal Player currentPlayer { get; set; }
        internal List<GameItem> Items { get; set; }
        internal List<Unit> Units { get; set; }
        internal List<Enemy> Enemies { get; set; }
        internal List<Snag> Snags { get; set; }
        internal List<Bonus> Bonuses { get; set; }

        internal Map CurrentMap { get; set; }

        internal GameProcessor()
        {
            CurrentMap = new Map(60, 40);
            currentPlayer = new Player();
            Items.Add(currentPlayer as GameItem);
            Items.Add(new Wolf(new Pos(15, 18), CurrentMap));
            Items.Add(new Wolf(new Pos(48, 3), CurrentMap));
            Items.Add(new Bear(new Pos(18, 17), CurrentMap));
            Items.Add(new Bear(new Pos(48, 6), CurrentMap));
            Items.Add(new Cherry(new Pos(8, 12), CurrentMap));
            Items.Add(new Cherry(new Pos(38, 6), CurrentMap));
            Items.Add(new Apple(new Pos(48, 14), CurrentMap));
            Items.Add(new Apple(new Pos(23, 32), CurrentMap));
            Items.Add(new Tree(new Pos(21, 16), CurrentMap));
            Items.Add(new Tree(new Pos(8, 12), CurrentMap));
            Items.Add(new Stone(new Pos(21, 16), CurrentMap));
            Items.Add(new Stone(new Pos(8, 12), CurrentMap));
            SortItems();

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
