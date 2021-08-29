using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Player : Unit
    {
        private int damage;
        private readonly int maxDamage = 80;
        private string playerName;
        private readonly int startHealth = 100;
        private readonly int signCode = 150;
        internal override int Damage { get => damage; set => damage = value; }
        internal string PlayerName
        {
            get => playerName;
            set
            {
                if (value.Length > 1 && value.Length < 20)
                {
                    playerName = value;
                }
            }
        }

        public Player() : this (new Pos(0, 0), new Map(), "Player 1")
        {
        }
        public Player(Pos currPos, Map currMap, string playerName): base (currPos, currMap)
        {
            PlayerName = playerName;
            Health = this.startHealth;
            SignCode = signCode;
            Damage = maxDamage;
        }
    }
}
