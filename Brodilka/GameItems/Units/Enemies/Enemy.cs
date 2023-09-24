using System;

namespace Brodilka.GameItems.Units.Enemies;

internal class Enemy : Unit
{
	internal Unit _player;

	public Enemy(Point currentPosition)
		: base(currentPosition)
	{
		_player = new Player("0", new Point(0, 0));
		IsItBlock = true;
		IsExist = true;
		ItemColor = ConsoleColor.Green;
	}

	internal override int Damage { get; set; }
	public override char Simbol { get; }

	public virtual Command GetEnemyDirection()
	{
		var rnd = new Random();
		var seed = rnd.Next(4);
		switch (seed + 1)
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
