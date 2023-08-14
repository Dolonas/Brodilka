using System.Runtime.Serialization;
using Brodilka.Interfaces;

namespace Brodilka.Units;

[KnownType(typeof(Unit))]
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

	protected Unit(Point position, int maxXPosition, int maxYPosition) : base(position, maxXPosition,  maxYPosition)
	{
		PreviousPosition = CurrentPosition;
		IsItBlock = false;
		IsExist = true;
	}

	public abstract Command GetCommand();
	public void Move(Command command)
	{
		PreviousPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition);
		switch (command)
		{
			case Command.Left:
				CurrentPosition = new Point(CurrentPosition.XPosition - 1, CurrentPosition.YPosition);
				break;
			case Command.Right:
				CurrentPosition = new Point(CurrentPosition.XPosition + 1, CurrentPosition.YPosition);
				break;
			case Command.Up:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition-1);
				break;
			case Command.Down:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition+1);
				break;
			default:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition+1);
				break;
		}

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
