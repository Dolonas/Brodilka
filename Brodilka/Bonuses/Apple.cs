
namespace Brodilka
{
    internal class Apple : Bonus
    {
        private readonly int appleSignCode = 36;
        private readonly int speedUp = 0;
        private readonly int healthUp = 70;

        public Apple()
        {

        }

        public Apple(Point currPosition, Map currMap) : base(currPosition, currMap)
        {
            this.SignCode = appleSignCode;
            this.SpeedUpForPlayer = speedUp;
            this.HealthUpForPlayer = healthUp;
        }
    }
}
