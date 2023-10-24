using System;

namespace Brodilka.GameItems.Units.Enemies;

internal class Bear : Enemy
{
	private double _tick;
	private int _x1, _y1, _x2, _y2;
	public Bear(Point currentPosition)
		: base(currentPosition)
	{
		Simbol = 'B';
		Damage = 2;
		Health = 70;
		Speed = 15;
		ItemDefaultColor = ItemColor.DarkGreen;
	}

	internal override Command GetEnemyDirection(Point humanPoint)
	{
		if (IsHumanNear(humanPoint) == UnitStatus.Pursuit)
			return ChasingHuman(humanPoint);
		var command = Command.Non;
		var temp = (int) (Math.Cos(_tick)*5);

		if ((int)_tick % 2 == 0)
			_x2 = temp;
		else
			_y2 = temp;

		if (_x2 == _x1 && _y2 == _y1)
			command = Command.Stop;
		else if (_x2 < _x1 && _y2 == _y1)
			command = Command.Left;
		else if (_x2 > _x1 && _y2 == _y1)
			command = Command.Right;
		else if (_x2 == _x1 && _y2 < _y1)
			command = Command.Up;
		else if (_x2 == _x1 && _y2 > _y1)
			command = Command.Down;
		else if (_x2 < _x1 && _y2 < _y1)
			command = Command.LeftUp;
		else if (_x2 > _x1 && _y2 < _y1)
			command = Command.RightUp;
		else if (_x2 < _x1 && _y2 > _y1)
			command = Command.LeftDown;
		else if (_x2 > _x1 && _y2 > _y1)
			command = Command.RightDown;
		_x1 = _x2;
		_y1 = _y2;
		_tick += 0.2;
		return command;
	}
}
