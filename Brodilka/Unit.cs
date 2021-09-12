using System;

namespace Brodilka
{
    abstract class Unit : GameItem, IMovable, IDamagable
    {
        private int health;
       
        public override bool IsItBlock { get; set; }
        public int Health 
        {
            get => health;
            set
            {
                if (value < 0)
                {
                    health = 0;
                }
                else
                {
                    health = value;
                }
            }
        }

        internal abstract int Damage { get; set;  }

        public Unit() : this (new Point(0, 0), new Map() )
        {

        }

        public Unit(Point pos, Map currentMap)
        {
            this.CurrMap = currentMap;
            this.CurrPoint = pos;
            this.IsItBlock = false;
        }
        

        public void Move(int xShift, int yShift)
        {
            this.CurrPoint.XPos += xShift;
            this.CurrPoint.YPos += yShift;
        }

        public void ToDamage(Unit unit, int Damage)
        {
            unit.GetDamage(Damage);
        }
        public void GetDamage(int damage)
        {
            this.Health -= damage;
        }

    }
}
