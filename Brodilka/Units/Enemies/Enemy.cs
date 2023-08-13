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
		var rnd = new Random();
		var direction = rnd.Next(4);
		PreviousPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition);
		switch (direction)
		{
			case 0:
				CurrentPosition = new Point(CurrentPosition.XPosition + 1, CurrentPosition.YPosition);
				break;
			case 1:
				CurrentPosition = new Point(CurrentPosition.XPosition - 1, CurrentPosition.YPosition);
				break;
			case 2:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition - 1);
				break;
			case 3:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition + 1);
				break;
			default:
				break;
		}
	}


}
