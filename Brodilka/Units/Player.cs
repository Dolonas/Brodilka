using System;

namespace Brodilka.Units
{
    internal class Player : Unit
    {
        private readonly int maxDamage = 80;
        private string playerName;
        private readonly int startHealth = 100;
        private readonly int signCode = 150;
        internal override int Damage { get; set; }

        private string PlayerName
        {
            get => playerName;
            set
            {
                if (value.Length is > 1 and < 20)
                {
                    playerName = value;
                }
            }
        }

        public Player() : this (new Point(0, 0), new Map(), "Player 1")
        {
        }
        public Player(Point currPos, Map currMap, string playerName): base (currPos, currMap)
        {
            PlayerName = playerName;
            Health = this.startHealth;
            SignCode = signCode;
            Damage = maxDamage;
        }

        public void Move(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    this.CurrPoint.XPos++;
                    break;
                case ConsoleKey.LeftArrow:
                    this.CurrPoint.XPos--;
                    break;
                case ConsoleKey.UpArrow:
                    this.CurrPoint.YPos--;
                    break;
                case ConsoleKey.DownArrow:
                    this.CurrPoint.YPos++;
                    break;
            }

        }

        
    }
}
