using System;

namespace Brodilka.GameItems.Units.Enemies;



internal class Enemy : Unit
{
	public Enemy(Point currentPosition)
		: base(currentPosition)
	{
		IsItBlock = true;
		IsExist = true;
		ItemDefaultColor = ItemColor.Green;
	}

	internal override int Damage { get; set; }
	public override char Simbol { get; }

	//public ConsoleColor ItemColor = ConsoleColor.Green;

	public virtual Command GetEnemyDirection(Point humanPoint)
	{
		var rnd = new Random();
		var seed = rnd.Next(4);
		return (seed + 1) switch
		{
			1 => Command.Left,
			2 => Command.Right,
			3 => Command.Up,
			4 => Command.Down,
			_ => Command.Non
		};
	}
}
