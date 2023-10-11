namespace Brodilka.GameItems.Bonuses;

internal abstract class Bonus : GameItem
{
	protected Bonus(Point point) : base(point)
	{
		IsItBlock = false;
		ItemDefaultColor = ItemColor.Magenta;
	}

	public int SpeedUpForPlayer { get; set; }
	public int HealthUpForPlayer { get; set; }
	public override bool IsItBlock { get; set; }
}
