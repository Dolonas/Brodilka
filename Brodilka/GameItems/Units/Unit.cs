using Brodilka.Interfaces;

namespace Brodilka.Units;

internal abstract class Unit : GameItem, IDamagable
{
	private int _health;
	public override bool IsItBlock { get; set; }
	public override Point PreviousPosition { get; set; }

	protected int Health
	{
		get => _health;
		set => _health = value < 0 ? 0 : _health = value;
	}

	internal abstract int Damage { get; set; }

	protected Unit(Point position, int maxXPos, int maxYPos) : base(position, maxXPos,  maxYPos)
	{
		PreviousPosition = CurrentPos;
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
		PreviousPosition = new Point(CurrentPos.XPos, CurrentPos.YPos);
		return command switch
		{
			Command.Left => new Point(CurrentPos.XPos - 1, CurrentPos.YPos),
			Command.Right => new Point(CurrentPos.XPos + 1, CurrentPos.YPos),
			Command.Up => new Point(CurrentPos.XPos, CurrentPos.YPos - 1),
			Command.Down => new Point(CurrentPos.XPos, CurrentPos.YPos + 1),
			_ => new Point(CurrentPos.XPos, CurrentPos.YPos)
		};
	}
}
