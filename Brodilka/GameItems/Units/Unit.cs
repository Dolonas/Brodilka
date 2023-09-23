using Brodilka.Interfaces;

namespace Brodilka.GameItems.Units;

internal abstract class Unit : GameItem, IDamagable
{
	private int _health;
	public override bool IsItBlock { get; set; }
	public Point PreviousPosition { get; set; }

	protected int Health
	{
		get => _health;
		set => _health = value < 0 ? 0 : _health = value;
	}

	internal abstract int Damage { get; set; }

	protected Unit(Point position) : base(position)
	{
		PreviousPosition = CurrPos;
		IsItBlock = false;
		IsExist = true;
	}

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
			Command.Right => new Point(CurrPos.XPos + 1, CurrPos.YPos),
			Command.Up => new Point(CurrPos.XPos, CurrPos.YPos - 1),
			Command.Down => new Point(CurrPos.XPos, CurrPos.YPos + 1),
			_ => new Point(CurrPos.XPos, CurrPos.YPos)
		};
	}
}
