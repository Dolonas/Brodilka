using System.Runtime.Serialization;
using Brodilka.Interfaces;

namespace Brodilka.Units;


internal abstract class Unit : GameItem, IMovable, IDamagable
{
	private int _health;

	public override bool IsItBlock { get; set; }
	public Point PreviousPos { get; set; }

	protected int Health
	{
		get => _health;
		set => _health = value < 0 ? 0 : _health = value;
	}

	internal abstract int Damage { get; set; }

	protected Unit() : this(new Point(0, 0), maxYPosition, maxXPosition)
	{
	}

	protected Unit(Point position, int maxYPosition, int maxXPosition) : base(maxXPosition,  maxYPosition)
	{
		CurrentPosition = position;
		PreviousPos = CurrentPosition;
		IsItBlock = false;
		IsExist = true;
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
