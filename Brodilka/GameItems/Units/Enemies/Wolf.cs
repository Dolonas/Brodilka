using System;

namespace Brodilka.GameItems.Units.Enemies;

internal class Wolf : Enemy
{
	private readonly int _wolfDamage = 20;
	private readonly int _wolfMaxHealth = 40;
	private double _tick;
	private int _x1, _y1, _x2, _y2;

	public Wolf(Point currentPosition)
		: base(currentPosition)
	{
		Simbol = 'w';
		Damage = _wolfDamage;
		Health = _wolfMaxHealth;
		var rnd = new Random();
		_tick = rnd.NextDouble();
		_x1 = _x2 = CurrPos.XPos;
		_y1 = _y2 = CurrPos.YPos;
	}

	public override char Simbol { get; }

	public override Command GetEnemyDirection()
	{
		if (IsHumanNear())
			return ChasingHuman();
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

	private bool IsHumanNear()
	{
		double distance = 0;
		if (CurrPos != null)
			distance =
				Math.Pow(
					Math.Pow(CurrPos.XPos - _player.CurrPos.XPos, 2) +
					Math.Pow(CurrPos.YPos - _player.CurrPos.YPos, 2), 0.5);
		else
			throw new NullReferenceException();

		return distance < 20;
	}

	private Command ChasingHuman()
	{
		var command = Command.Non;
		var angle = Math.Atan2(CurrPos.XPos - _player.CurrPos.XPos, CurrPos.YPos - _player.CurrPos.YPos);
		if (angle is > 0 and < 0.395 or < 0 and > -0.395)
			command = Command.Up;
		else if (angle is < -0.395 and > -1.18)
			command = Command.RightUp;
		else if (angle is < -1.18 and > -1.965)
			command = Command.Right;
		else if (angle is < -1.965 and > -2.75)
			command = Command.RightDown;
		else if (angle is < -2.75 or > -2.75)
			command = Command.Down;
		else if (angle is > 1.965 and < 2.75)
			command = Command.LeftDown;
		else if (angle is > 1.18 and < 1.965)
			command = Command.Left;
		else if (angle is > 0.395 and < 1.18)
			command = Command.LeftUp;
		return command;
	}
}
