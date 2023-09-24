using System;

namespace Brodilka.GameItems.Obstacles;

public abstract class Obstacle : GameItem
{
	protected Obstacle(Point position) : base(position)
	{
		CurrPos = position;
		IsExist = true;
		IsItBlock = true;
		ItemColor = ConsoleColor.Yellow;
	}

	public override bool IsItBlock { get; set; }
}
