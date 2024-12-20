﻿using System;

namespace Brodilka.GameItems.Units.Enemies;

internal class Wolf : Enemy
{
	private double _tick;
	private int _x1, _y1, _x2, _y2;

	public Wolf(Point currentPosition)
		: base(currentPosition)
	{
		Simbol = 'w';
		Damage = 2;
		Health = 40;
		Speed = 16;
		var rnd = new Random();
		_tick = rnd.NextDouble();
		_x1 = _x2 = Pos.XPos;
		_y1 = _y2 = Pos.YPos;
	}

	internal sealed override int Damage
	{
		get => base.Damage;
		set => base.Damage = value;
	}

	internal override Command GetEnemyDirection(Point humanPoint)
	{
		if (IsHumanNear(humanPoint) == UnitStatus.Pursuit)
			return ChasingHuman(humanPoint);
		var command = Command.Non;
		_x2 = (int)Math.Round(_x1 + (3 * Math.Cos(2 * _tick) * Math.Cos(_tick)));
		_y2 = (int)Math.Round(_y1 + (3 * Math.Cos(2 * _tick) * Math.Sin(_tick)));
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
