namespace Brodilka.GameItems.Bonuses;

internal abstract class Bonus : GameItem
{
	protected Bonus(Point point) : base(point)
	{
		IsItBlock = false;
		ItemDefaultColor = ItemColor.Magenta;
	}

	internal int SpeedUpForPlayer { get; set; }
	internal int HealthUpForPlayer { get; set; }
	internal override bool IsItBlock { get; set; }
}
