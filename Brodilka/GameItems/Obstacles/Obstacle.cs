using System;

namespace Brodilka.GameItems.Obstacles;

public abstract class Obstacle : GameItem
{
	protected Obstacle(Point position) : base(position)
	{
		Pos = position;
		IsExist = true;
		IsItBlock = true;
		ItemColor = ItemColor.Yellow;
	}

	public override bool IsItBlock { get; set; }
}
