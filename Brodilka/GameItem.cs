namespace Brodilka;

public abstract class GameItem
{
	private readonly Point currentPosition;
	protected Map CurrentMap { get; set; }


	public bool IsExist { get; set; }

	public Point CurrentPosition
	{
		get => currentPosition;
		protected init
		{
			if (value.XPosition <= -1 ||
			    value.YPosition <= -1 ||
			    value.XPosition >= CurrentMap.XSize ||
			    value.YPosition >= CurrentMap.YSize) return;
			//PreviousPos = CurrentPosition;
			currentPosition = value;
		}
	}

	//protected GameItem() => PreviousPos = new Point(0, 0);

	public abstract bool IsItBlock { get; set; }
	public void Update()
	{

	}
}
