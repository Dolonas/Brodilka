
namespace Brodilka;
    internal class Cherry : Bonus
    {
        private readonly int cherrySignCode = 31;
        private readonly int speedUp = 5;
        private readonly int healthUp = 0;

        public Cherry()
        {

        }

        public Cherry(Point currPosition, Map currMap) : base(currPosition, currMap)
        {
            this.SignCode = cherrySignCode;
            this.SpeedUpForPlayer = speedUp;
            this.HealthUpForPlayer = healthUp;
        }

    }
