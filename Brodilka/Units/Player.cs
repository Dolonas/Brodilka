using System.Runtime.Serialization;

namespace Brodilka.Units;

[KnownType(typeof(Player))]
internal class Player : Unit
{
	private const int MaxDamage = 80;
	private readonly string playerName;
	private const int StartHealth = 100;
	internal sealed override int Damage { get; set; }

	private string PlayerName
	{
		get => playerName;
		init => playerName = value.Length is > 1 and < 20 ? value : playerName;
	}

	public Player() : this(new Point(0, 0), new Map(), "Player 1")
	{
	}

	public Player(Point currentPosition, Map currMap, string playerName) : base(currentPosition, currMap)
	{
		PlayerName = playerName;
		Health = StartHealth;
		Damage = MaxDamage;
	}

	public void Move(Command command)
	{
		switch (command)
		{
			case Command.Right:
				CurrentPosition.XPosition++;
				break;
			case Command.Left:
				CurrentPosition.XPosition--;
				break;
			case Command.Up:
				CurrentPosition.YPosition--;
				break;
			case Command.Down:
				CurrentPosition.YPosition++;
				break;
		}
	}
}
