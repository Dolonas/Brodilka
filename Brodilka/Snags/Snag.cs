namespace Brodilka.Snags;

internal abstract class Snag : GameItem
{
	private bool isItBlock;
	public override bool IsItBlock { get => isItBlock; set => isItBlock = value; }

	public Snag() : this(new Point(0, 0), new Map())
	{
	}

	public Snag(Point currPoint, Map currMap)
	{
		CurrentMap = currMap;
		CurrentPosition = currPoint;

		IsItBlock = true;
	}
}
