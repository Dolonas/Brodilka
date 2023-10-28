using System;

namespace Brodilka.GameItems.Units.Enemies;

internal abstract class Enemy : Unit
{
	private readonly Random _rnd = new ();
	internal Enemy(Point currentPosition)
		: base(currentPosition)
	{
		IsItBlock = true;
		IsExist = true;
		ItemDefaultColor = ItemColor.Green;
	}

	internal override int Damage { get; set; }

	internal virtual Command GetEnemyDirection(Point humanPoint)
	{

		var seed = _rnd.Next(4);
		return (seed + 1) switch
		{
			1 => Command.Left,
			2 => Command.Right,
			3 => Command.Up,
			4 => Command.Down,
			_ => Command.Non
		};
	}

	internal UnitStatus IsHumanNear(Point humanPoint)
	{
		double distance;
		if (Pos != null)
		{
			distance =
				Math.Pow(
					Math.Pow(Pos.XPos - humanPoint.XPos, 2) +
					Math.Pow(Pos.YPos - humanPoint.YPos, 2), 0.5);
		}
		else
			return UnitStatus.Patrol;

		switch (distance)
		{
			case < 2:
				UnitStatus = UnitStatus.Attack;
				return UnitStatus.Attack;
			case < 10:
				UnitStatus = UnitStatus.Pursuit;
				return UnitStatus.Pursuit;
			default:
				UnitStatus = UnitStatus.Patrol;
				return UnitStatus.Patrol;
		}
	}

	internal Command ChasingHuman(Point humanPoint)
	{
		UnitStatus = UnitStatus.Pursuit;
		var command = Command.Non;
		var angle = Math.Atan2(Pos.XPos - humanPoint.XPos, Pos.YPos - humanPoint.YPos);
		if (angle is >= 0 and < 0.395 or <= 0 and > -0.395)
			command = Command.Up;
		else if (angle is < -0.395 and > -1.18)
			command = Command.RightUp;
		else if (angle is <= -1.18 and > -1.965)
			command = Command.Right;
		else if (angle is <= -1.965 and > -2.75)
			command = Command.RightDown;
		else if (angle is <= -2.75 or >= 2.75)
			command = Command.Down;
		else if (angle is >= 1.965 and < 2.75)
			command = Command.LeftDown;
		else if (angle is > 1.18 and < 1.965)
			command = Command.Left;
		else if (angle is >= 0.395 and <= 1.18)
			command = Command.LeftUp;
		return command;
	}
}
