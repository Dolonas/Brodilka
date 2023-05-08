namespace Brodilka;

internal abstract class Bonus : GameItem
{
	private bool isItBlock;
	public int SpeedUpForPlayer { get; set; }
	public int HealthUpForPlayer { get; set; }
	public override bool IsItBlock { get => isItBlock; set => isItBlock = value; }

	public Bonus() : this(new Point(0, 0), new Map())
	{
	}

	public Bonus(Point currPosition, Map currMap)
	{
		CurrentMap = currMap;
		CurrentPosition = currPosition;

		IsItBlock = false;
	}
}
