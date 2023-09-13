using System;

namespace Brodilka.GameItems.Obstacles;

public abstract class Obstacle : GameItem
{
	public override bool IsItBlock { get; set; }

	public sealed override Point PreviousPosition { get; set; }

	protected Obstacle(Point position, int maxXPos, int maxYPos) : base(position, maxXPos, maxYPos)
	{
		CurrentPos = position;
		PreviousPosition = position;
		IsExist = true;
		IsItBlock = true;
		ItemColor = ConsoleColor.Yellow;
	}
}
