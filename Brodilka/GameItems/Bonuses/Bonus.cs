using System;
using System.Runtime.Serialization;

namespace Brodilka.Bonuses;

internal abstract class Bonus : GameItem
{
	public sealed override Point PreviousPosition { get; set; }
	protected int SpeedUpForPlayer { get; set; }
	protected int HealthUpForPlayer { get; set; }
	public override bool IsItBlock { get; set; }

	protected Bonus(Point currentPoint, int maxXPos, int maxYPos) : base(currentPoint, maxXPos, maxYPos)
	{
		PreviousPosition = CurrentPos;
		IsItBlock = false;
		ItemColor = ConsoleColor.Magenta;
	}
}
