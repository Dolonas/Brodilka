namespace Brodilka.Units
{
    abstract class Unit : GameItem, IMovable, IDamagable
    {
        private int health;
       
        public override bool IsItBlock { get; set; }

        protected int Health 
        {
            get => health;
            set => health = value < 0 ? 0 : value;
        }

        internal abstract int Damage { get; set;  }

        protected Unit() : this (new Point(0, 0), new Map() )
        {

        }

        protected Unit(Point pos, Map currentMap)
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

        public void ToDamage(Unit unit, int damage)
        {
            unit.GetDamage(damage);
        }
        public void GetDamage(int damage)
        {
            this.Health -= damage;
        }

    }
}
