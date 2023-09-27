using System;

namespace Brodilka;

public abstract class GameItem
{
	private ConsoleColor _itemDefaultColor = ConsoleColor.White;
	public GameItem(Point currPos) => CurrPos = currPos;

	public bool IsExist { get; set; }

	protected ConsoleColor ItemDefaultColor
	{
		get => _itemDefaultColor;
		set => _itemDefaultColor = ItemColor = value;
	}

	public ConsoleColor ItemColor { get; protected set; }

	public Point CurrPos { get; set; }

	public abstract bool IsItBlock { get; set; }
	public abstract char Simbol { get; }
}
