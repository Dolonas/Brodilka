namespace Brodilka;

internal abstract class GameItem
{
	private Point currentPosition;
	public Map CurrentMap { get; set; }
	public int SignCode { get; set; }
	public Point PreviousPos { get; set; }

	public Point CurrentPosition
	{
		get => currentPosition;
		set
		{
			if (value.XPosition > -1 &&
			    value.YPosition > -1 &&
			    value.XPosition < CurrentMap.XSize &&
			    value.YPosition < CurrentMap.YSize)

			{
				PreviousPos = CurrentPosition;
				currentPosition = value;
			}
		}
	}

	public GameItem() => PreviousPos = new Point(0, 0);

	public abstract bool IsItBlock { get; set; }
}
