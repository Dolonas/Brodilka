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

	public void ToDamage(Unit unit, int Damage)
	{
		unit.GetDamage(Damage);
	}

	public void GetDamage(int damage)
	{
		Health -= damage;
	}
}
