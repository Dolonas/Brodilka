using System;
using System.Runtime.Serialization;

namespace Brodilka.Units;

[KnownType(typeof(Player))]
internal class Player : Unit
{
	private const int MaxDamage = 80;
	private readonly string _playerName;
	private const int StartHealth = 100;
	internal sealed override int Damage { get; set; }
	public override char Simbol { get; }
	public override Point PreviousPosition { get; set; }

	private string PlayerName
	{
		get => _playerName;
		init => _playerName = value.Length is > 1 and < 20 ? value : _playerName;
	}

	public Player(string playerName, Point currentPosition, int maxXPosition, int maxYPosition)
		: base(currentPosition, maxXPosition, maxYPosition)

	{
		PreviousPosition = currentPosition;
		PlayerName = playerName;
		Simbol = 'P';
		Health = StartHealth;
		Damage = MaxDamage;
		ItemColor = ConsoleColor.Blue;
	}

	public void Move(Command command)
	{
		PreviousPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition);
		switch (command)
		{
			case Command.Right:
				CurrentPosition = new Point(CurrentPosition.XPosition + 1, CurrentPosition.YPosition);
				break;
			case Command.Left:
				CurrentPosition = new Point(CurrentPosition.XPosition - 1, CurrentPosition.YPosition);;
				break;
			case Command.Up:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition - 1);
				break;
			case Command.Down:
				CurrentPosition = new Point(CurrentPosition.XPosition, CurrentPosition.YPosition + 1);
				break;
		}
	}
}
