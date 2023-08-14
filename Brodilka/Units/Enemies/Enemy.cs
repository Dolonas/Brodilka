using System;
using System.Runtime.Serialization;

namespace Brodilka.Units.Enemies;

[KnownType(typeof(Enemy))]
internal class Enemy : Unit
{
	internal override int Damage { get; set; }
	public override char Simbol { get; }

	public override Point PreviousPosition { get; set; }

	public Enemy(Point currentPosition, int maxXPosition, int maxYPosition)
		: base(currentPosition, maxXPosition, maxYPosition)
	{
		IsItBlock = true;
		IsExist = true;
		ItemColor = ConsoleColor.Green;
	}

	public override Command GetCommand()
	{
		var rnd = new Random(0);
		var seed = rnd.Next(3);
		switch (seed)
		{
			case 0:
				return Command.Left;
			case 1:
				return Command.Right;
			case 2:
				return Command.Up;
			case 3:
				return Command.Down;
		}

		return Command.Non;
	}
}
