using System;
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

        public Enemy(Pos currPos, Map currMap) : base(currPos, currMap)
        {
        }

        public void Move()
        {
            Random rnd = new Random();
            int direction = rnd.Next(3);
            switch (direction)
            {
                case 0:
                    this.CurrPos.XPos -= 1;
                    break;
                case 1:
                    this.CurrPos.YPos -= 1;
                    break;
                case 2:
                    this.CurrPos.XPos += 1;
                    break;
                case 3:
                    this.CurrPos.YPos += 1;
                    break;
                default:
                    break;
            }
        }
    }
}
