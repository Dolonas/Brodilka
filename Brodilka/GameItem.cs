using System.Runtime.Serialization;

namespace Brodilka;

[DataContract()]
public abstract class GameItem
{
	private Point _currentPosition;
	//protected Map CurrentMap { get; set; }
	private readonly int _maxXPosition;
	private readonly int _maxYPosition;
	public bool IsExist { get; set; }

	public GameItem(int maxXPosition, int maxYPosition)
	{
		_maxXPosition = maxXPosition;
		_maxYPosition = maxYPosition;
	}
	public Point CurrentPosition
	{
		get => _currentPosition;
		protected init
		{
			if (value.XPosition <= -1 ||
			    value.YPosition <= -1 ||
			    value.XPosition >= _maxXPosition ||
			    value.YPosition >= _maxYPosition) return;
			_currentPosition = value;
		}
	}

	//protected GameItem() => PreviousPos = new Point(0, 0);

	public abstract bool IsItBlock { get; set; }
	public void Update()
	{

	}
}
