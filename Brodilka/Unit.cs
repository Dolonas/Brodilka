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
            this.CurrentMap = currentMap;
            this.CurrentPos = pos;
            this.PreviousPos = CurrentPos;
            this.IsItBlock = false;
        }
        

        public void Move(int xShift, int yShift)
        {
            this.CurrentPos.XPosition += xShift;
            this.CurrentPos.YPosition += yShift;
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
