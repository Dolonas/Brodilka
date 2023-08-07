﻿namespace Brodilka.Units.Enemies;

internal class Bear : Enemy
{
	public Bear() : this(new Point(0, 0), new Map())
	{
	}

	public Bear(Point currPosition, Map currMap) : base(currPosition, currMap)
	{
		Damage = 40;
		Health = 100;
		IsItBlock = false;
	}
}