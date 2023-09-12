using System;

namespace Brodilka;

public abstract class GameItem
{
	private Point _currentPos;
	private readonly int _maxXPos;
	private readonly int _maxYPos;
	public bool IsExist { get; set; }
	public ConsoleColor ItemColor { get; set; }

	public GameItem(Point currentPos, int maxXPos, int maxYPos)
	{
		_currentPos = currentPos;
		_maxXPos = maxXPos;
		_maxYPos = maxYPos;
	}
	public Point CurrentPos
	{
		get => _currentPos;
		set
		{
			if (value.XPos < 0 ||
			    value.YPos < 0 ||
			    value.XPos >= _maxXPos ||
			    value.YPos >= _maxYPos-3) return;
			_currentPos = value;
		}
	}
	public abstract Point PreviousPosition { get; set; }

	public abstract bool IsItBlock { get; set; }
	public abstract char Simbol { get; }
	public void Update()
	{

	}
}
