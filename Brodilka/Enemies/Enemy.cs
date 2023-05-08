using System;

namespace Brodilka;

internal class Enemy : Unit
{
	private int damage;
	internal override int Damage { get => damage; set => damage = value; }

	public Enemy(Point currPosition, Map currMap) : base(currPosition, currMap)
	{
	}

	public void Move()
	{
		var rnd = new Random();
		var direction = rnd.Next(3);
		switch (direction)
		{
			case 0:
				CurrentPosition.XPosition -= 1;
				break;
			case 1:
				CurrentPosition.YPosition -= 1;
				break;
			case 2:
				CurrentPosition.XPosition += 1;
				break;
			case 3:
				CurrentPosition.YPosition += 1;
				break;
			default:
				break;
		}
	}
}
