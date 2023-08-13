using System.Runtime.Serialization;

namespace Brodilka.Snags;

[DataContract()]
public abstract class Snag : GameItem
{
	public override bool IsItBlock { get; set; }

	public sealed override Point PreviousPosition { get; set; }

	protected Snag(Point position, int maxXPos, int maxYPos) : base(position, maxXPos, maxYPos)
	{
		CurrentPosition = position;
		PreviousPosition = position;
		IsExist = true;
		IsItBlock = true;
	}
}
