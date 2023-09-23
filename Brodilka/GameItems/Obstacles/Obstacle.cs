using System;

namespace Brodilka.GameItems.Obstacles;

public abstract class Obstacle : GameItem
{
	public override bool IsItBlock { get; set; }

	protected Obstacle(Point position) : base(position)
	{
		CurrPos = position;
		IsExist = true;
		IsItBlock = true;
		ItemColor = ConsoleColor.Yellow;
	}
}
