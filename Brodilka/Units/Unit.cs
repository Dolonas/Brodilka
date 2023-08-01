using Brodilka.Interfaces;

namespace Brodilka.Units;

internal abstract class Unit : GameItem, IMovable, IDamagable
{
	private int health;

	public override bool IsItBlock { get; set; }

	protected int Health
	{
		get => health;
		set => health = value < 0 ? 0 : health = value;
	}

	internal abstract int Damage { get; set; }

	public Unit() : this(new Point(0, 0), new Map())
	{
	}

	public Unit(Point position, Map currentMap)
	{
		CurrentMap = currentMap;
		CurrentPosition = position;
		PreviousPos = CurrentPosition;
		IsItBlock = false;
	}


	public void Move(int xShift, int yShift)
	{
		CurrentPosition.XPosition += xShift;
		CurrentPosition.YPosition += yShift;
	}

	public void ToDamage(Unit unit, int Damage)
	{
		unit.GetDamage(Damage);
	}

	public void GetDamage(int damage)
	{
		Health -= damage;
	}
}
