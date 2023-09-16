using System;

namespace Brodilka.GameItems.Obstacles;

public abstract class Obstacle : GameItem
{
	public override bool IsItBlock { get; set; }

	protected Obstacle(Point position) : base(position)
	{
		CurrentPos = position;
		IsExist = true;
		IsItBlock = true;
		ItemColor = ConsoleColor.Yellow;
	}
}
