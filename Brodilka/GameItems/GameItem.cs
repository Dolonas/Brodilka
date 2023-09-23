using System;

namespace Brodilka;

public abstract class GameItem
{
	//private Point _currentPos;
	// private readonly int _maxXPos;
	// private readonly int _maxYPos;
	public bool IsExist { get; set; }
	public ConsoleColor ItemColor { get; set; }

	public GameItem(Point currPos) => CurrPos = currPos;

	public Point CurrPos { get; set; }

	public abstract bool IsItBlock { get; set; }
	public abstract char Simbol { get; }
	public void Update()
	{

	}
}
