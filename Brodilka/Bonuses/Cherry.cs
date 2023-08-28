using System.Runtime.Serialization;
using Brodilka.Units;

namespace Brodilka.Bonuses;

internal class Cherry : Bonus
{
	private readonly int _speedUp = 5;
	private readonly int _healthUp = 0;

	public override char Simbol { get; }

	public Cherry(Point currentPoint, int maxXPos, int maxYPos) : base(currentPoint, maxXPos, maxYPos)
	{
		Simbol = 'y';
		SpeedUpForPlayer = _speedUp;
		HealthUpForPlayer = _healthUp;
		IsExist = true;
	}
}
