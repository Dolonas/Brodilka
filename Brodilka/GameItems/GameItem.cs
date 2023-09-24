using System;

namespace Brodilka;

public abstract class GameItem
{
	public GameItem(Point currPos) => CurrPos = currPos;

	public bool IsExist { get; set; }
	public ConsoleColor ItemColor { get; set; }

	public Point CurrPos { get; set; }

	public abstract bool IsItBlock { get; set; }
	public abstract char Simbol { get; }

	public void Update()
	{
	}
}
