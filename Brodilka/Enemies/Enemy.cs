﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brodilka
{
    internal class Enemy : Unit
    {
        private int damage;
        internal override int Damage { get => damage; set => damage = value; }        

        public Enemy(Point currPos, Map currMap) : base(currPos, currMap)
        {
        }

        public void Move()
        {
            Random rnd = new Random();
            int direction = rnd.Next(3);
            switch (direction)
            {
                case 0:
                    this.CurrentPos.XPosition -= 1;
                    break;
                case 1:
                    this.CurrentPos.YPosition -= 1;
                    break;
                case 2:
                    this.CurrentPos.XPosition += 1;
                    break;
                case 3:
                    this.CurrentPos.YPosition += 1;
                    break;
                default:
                    break;
            }
        }
    }
}