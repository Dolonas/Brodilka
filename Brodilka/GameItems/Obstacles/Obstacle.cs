namespace Brodilka.GameItems.Obstacles;

internal abstract class Obstacle : GameItem
{
	internal Obstacle(Point position) : base(position)
	{
		Pos = position;
		IsExist = true;
		IsItBlock = true;
		ItemColor = ItemColor.Yellow;
	}

	internal override bool IsItBlock { get; set; }
}
