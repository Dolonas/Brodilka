
namespace Brodilka
{
    internal abstract class Bonus : GameItem
    {
        private bool isItBlock = false;
        public int SpeedUpForPlayer { get; set; }
        public int HealthUpForPlayer { get; set; }
        public override bool IsItBlock { get => isItBlock; set => isItBlock = value; }

        public Bonus() : this(new Point(0, 0), new Map())
        {

        }

        public Bonus(Point currPosition, Map currMap)
        {
            this.CurrentMap = currMap;
            this.CurrentPosition = currPosition;
            
            this.IsItBlock = false;

        }
    }
}
