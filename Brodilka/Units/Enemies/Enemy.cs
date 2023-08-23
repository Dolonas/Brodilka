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
	public void Move()
	{
		var command = GetKeyboardReceive();
		PreviousPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition);
		switch (command)
		{
			case Command.Left:
				CurrentPosition = new Point(CurrentPosition.XPosition - 1, CurrentPosition.YPosition);
				break;
			case Command.Right:
				CurrentPosition = new Point(CurrentPosition.XPosition + 1, CurrentPosition.YPosition);
				break;
			case Command.Up:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition-1);
				break;
			case Command.Down:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition+1);
				break;
			default:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition);
				break;
		}
	}
	public Command GetKeyboardReceive()
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
