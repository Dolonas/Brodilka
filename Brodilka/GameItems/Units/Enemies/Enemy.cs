using System;

namespace Brodilka.GameItems.Units.Enemies;



internal class Enemy : Unit
{
	public Enemy(Point currentPosition)
		: base(currentPosition)
	{
		IsItBlock = true;
		IsExist = true;
		ItemDefaultColor = ConsoleColor.Green;
	}

	internal override int Damage { get; set; }
	public override char Simbol { get; }

	//public ConsoleColor ItemColor = ConsoleColor.Green;

	public virtual Command GetEnemyDirection(Point humanPoint)
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
