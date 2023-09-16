﻿using System;

namespace Brodilka.GameItems.Bonuses;

internal abstract class Bonus : GameItem
{
	protected int SpeedUpForPlayer { get; set; }
	protected int HealthUpForPlayer { get; set; }
	public override bool IsItBlock { get; set; }

	protected Bonus(Point currentPoint) : base(currentPoint)
	{
		IsItBlock = false;
		ItemColor = ConsoleColor.Magenta;
	}
}
