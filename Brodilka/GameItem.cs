using System;
using System.Runtime.Serialization;

namespace Brodilka;

[KnownType(typeof(GameItem))]
public abstract class GameItem
{
	private Point _currentPosition;
	private readonly int _maxXPosition;
	private readonly int _maxYPosition;
	public bool IsExist { get; set; }
	public ConsoleColor ItemColor { get; set; }

	public GameItem(Point currentPosition, int maxXPosition, int maxYPosition)
	{
		// ReSharper disable once VirtualMemberCallInConstructor
		_currentPosition = currentPosition;
		//PreviousPosition = currentPosition;
		_maxXPosition = maxXPosition;
		_maxYPosition = maxYPosition;
	}
	public Point CurrentPosition
	{
		get => _currentPosition;
		set
		{
			if (value.XPosition < 0 ||
			    value.YPosition < 0 ||
			    value.XPosition >= _maxXPosition ||
			    value.YPosition >= _maxYPosition-3) return;
			_currentPosition = value;
		}
	}
	public abstract Point PreviousPosition { get; set; }

	public abstract bool IsItBlock { get; set; }
	public abstract char Simbol { get; }
	public void Update()
	{

	}
}
