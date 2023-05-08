using System;

namespace Brodilka;
    internal class Enemy : Unit
    {
        private int damage;
        internal override int Damage { get => damage; set => damage = value; }        

        public Enemy(Point currPosition, Map currMap) : base(currPosition, currMap)
        {
        }

        public void Move()
        {
            Random rnd = new Random();
            int direction = rnd.Next(3);
            switch (direction)
            {
                case 0:
                    this.CurrentPosition.XPosition -= 1;
                    break;
                case 1:
                    this.CurrentPosition.YPosition -= 1;
                    break;
                case 2:
                    this.CurrentPosition.XPosition += 1;
                    break;
                case 3:
                    this.CurrentPosition.YPosition += 1;
                    break;
                default:
                    break;
            }
        }
    }
