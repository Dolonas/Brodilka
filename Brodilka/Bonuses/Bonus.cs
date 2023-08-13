using System.Runtime.Serialization;

namespace Brodilka.Bonuses;

[DataContract()]
internal abstract class Bonus : GameItem
{
	public sealed override Point PreviousPosition { get; set; }
	protected int SpeedUpForPlayer { get; set; }
	protected int HealthUpForPlayer { get; set; }
	public override bool IsItBlock { get; set; }

	protected Bonus(Point currPoint, int maxXPos, int maxYPos) : base(currPoint, maxXPos, maxYPos)
	{
		PreviousPosition = CurrentPosition;
		IsItBlock = false;
	}
}
