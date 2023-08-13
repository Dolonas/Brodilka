using System.Runtime.Serialization;
using Brodilka.Interfaces;

namespace Brodilka.Units;

[KnownType(typeof(Unit))]
internal abstract class Unit : GameItem, IMovable, IDamagable
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

	protected Unit(Point position, int maxXPosition, int maxYPosition) : base(position, maxXPosition,  maxYPosition)
	{
		PreviousPosition = CurrentPosition;
		IsItBlock = false;
		IsExist = true;
	}


	public void Move(int xShift, int yShift)
	{
		CurrentPosition = new Point(CurrentPosition.XPosition + xShift, CurrentPosition.YPosition + yShift);
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
