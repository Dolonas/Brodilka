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
		PreviousPosition = Pos;
		IsItBlock = false;
		IsExist = true;
		UnitStatus = UnitStatus.Patrol;
		SpeedCounter = 0;
	}

	internal sealed override bool IsItBlock { get; set; }
	public Point PreviousPosition { get; set; }
	public int SpeedCounter { get; set; }

	public UnitStatus UnitStatus
	{
		get => _unitStatus;
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

	internal int Speed { get; set; }

	internal abstract int Damage { get; set; }

	public void ToDamage(Unit unit)
	{
		unit.GetDamage(Damage);
	}

	public void GetDamage(int damage)
	{
		Health -= damage;
	}

	public Point Move(Command command)
	{
		PreviousPosition = new Point(Pos.XPos, Pos.YPos);
		return command switch
		{
			Command.Left => new Point(Pos.XPos - 1, Pos.YPos),
			Command.LeftUp => new Point(Pos.XPos - 1, Pos.YPos - 1),
			Command.Up => new Point(Pos.XPos, Pos.YPos - 1),
			Command.RightUp => new Point(Pos.XPos + 1, Pos.YPos - 1),
			Command.Right => new Point(Pos.XPos + 1, Pos.YPos),
			Command.RightDown => new Point(Pos.XPos + 1, Pos.YPos + 1),
			Command.Down => new Point(Pos.XPos, Pos.YPos + 1),
			Command.LeftDown => new Point(Pos.XPos - 1, Pos.YPos + 1),
			_ => new Point(Pos.XPos, Pos.YPos)
		};
	}
}
