﻿namespace Brodilka.GameItems.Units.Enemies;

internal class Bear : Enemy
{
	private readonly int _bearDamage = 40;
	private readonly int _bearHealth = 70;

	public override char Simbol { get; }

	public Bear(Point currentPosition, int maxXPos, int maxYPos)
		: base(currentPosition, maxXPos, maxYPos)
	{
		Simbol = 'B';
		Damage = _bearDamage;
		Health = _bearHealth;
	}

}
