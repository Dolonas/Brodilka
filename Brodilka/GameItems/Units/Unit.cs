using System;
using Brodilka.Interfaces;

namespace Brodilka.GameItems.Units;

internal enum UnitStatus
{
	Patrol, Pursuit, Attack
}

internal abstract class Unit : GameItem, IDamagable
{
	private int _health;
	private UnitStatus _unitStatus;

	protected Unit(Point position) : base(position)
	{
		PreviousPosition = CurrPos;
		IsItBlock = false;
		IsExist = true;
		UnitStatus = UnitStatus.Patrol;
	}

	public override bool IsItBlock { get; set; }
	public Point PreviousPosition { get; set; }

	protected UnitStatus UnitStatus
	{
		//get => _unitStatus;
		set
		{
			_unitStatus = value;
			ItemColor = value switch
			{
				UnitStatus.Patrol => ItemDefaultColor,
				UnitStatus.Pursuit => ItemColor.DarkMagenta,
				UnitStatus.Attack => ItemColor.Red,
				_ => ItemColor
			};
		}
	}

	internal int Health
	{
		get => _health;
		set => _health = value < 0 ? 0 : _health = value;
	}

	internal abstract int Damage { get; set; }

	public void ToDamage(Unit unit, int damage)
	{
		unit.GetDamage(damage);
	}

	public void GetDamage(int damage)
	{
		Health -= damage;
	}

	public Point Move(Command command)
	{
		PreviousPosition = new Point(CurrPos.XPos, CurrPos.YPos);
		return command switch
		{
			Command.Left => new Point(CurrPos.XPos - 1, CurrPos.YPos),
			Command.LeftUp => new Point(CurrPos.XPos - 1, CurrPos.YPos - 1),
			Command.Up => new Point(CurrPos.XPos, CurrPos.YPos - 1),
			Command.RightUp => new Point(CurrPos.XPos + 1, CurrPos.YPos - 1),
			Command.Right => new Point(CurrPos.XPos + 1, CurrPos.YPos),
			Command.RightDown => new Point(CurrPos.XPos + 1, CurrPos.YPos + 1),
			Command.Down => new Point(CurrPos.XPos, CurrPos.YPos + 1),
			Command.LeftDown => new Point(CurrPos.XPos - 1, CurrPos.YPos + 1),
			_ => new Point(CurrPos.XPos, CurrPos.YPos)
		};
	}
}
