namespace Brodilka.Units
{
    internal class Wolf : Enemy
    {

        public Wolf() : this (new Point(0,0), new Map())
        {

        }
        public Wolf(Point currPos, Map currMap) : base(currPos, currMap)
        {
            Damage = 20;
            Health = 40;
            SignCode = 220;
            this.IsItBlock = false;
            

        }
    }
}
