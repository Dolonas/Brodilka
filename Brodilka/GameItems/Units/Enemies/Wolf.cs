using System;

namespace Brodilka.GameItems.Units.Enemies;

internal class Wolf : Enemy
{
	private readonly int _wolfDamage = 20;
	private readonly int _wolfMaxHealth = 40;
	private int _tick;
	private double _x1, _y1;

	public override char Simbol { get; }

	public Wolf(Point currentPosition, int maxXPos, int maxYPos)
		: base(currentPosition, maxXPos, maxYPos)
	{
		Simbol = 'w';
		Damage = _wolfDamage;
		Health = _wolfMaxHealth;
		_tick = 0;
		_y1 = 0;
		_x1 = 0;
	}

	public override Command GetEnemyDirection()
	{
		var x2 = Math.Cos(3 * _tick) * Math.Cos(_tick)*4;
		var y2 = Math.Cos(3 * _tick) * Math.Sin(_tick++)*4;

		switch ((int)(x2 + y2))
		{
			case 1:
				return Command.Left;
			case 2:
				return Command.Right;
			case 3:
				return Command.Up;
			case 4:
				return Command.Down;
		}

		return Command.Non;
	}
}
