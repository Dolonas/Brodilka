using System;

namespace Brodilka.GameItems.Bonuses;

internal abstract class Bonus : GameItem
{
	protected Bonus(Point currPoint) : base(currPoint)
	{
		IsItBlock = false;
		ItemColor = ConsoleColor.Magenta;
	}

	protected int SpeedUpForPlayer { get; set; }
	protected int HealthUpForPlayer { get; set; }
	public override bool IsItBlock { get; set; }
}
