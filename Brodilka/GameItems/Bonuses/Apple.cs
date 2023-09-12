using System.Runtime.Serialization;
using Brodilka.Units;

namespace Brodilka.Bonuses;

internal class Apple : Bonus
{
	private readonly int speedUp = 0;
	private readonly int healthUp = 70;
	public override char Simbol { get; }

	public Apple(Point currentPoint, int maxXPos, int maxYPos) : base(currentPoint, maxXPos, maxYPos)
	{
		Simbol = 'a';
		SpeedUpForPlayer = speedUp;
		HealthUpForPlayer = healthUp;
		IsExist = true;
	}


}
