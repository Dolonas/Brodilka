using System;
using System.Runtime.Serialization;

namespace Brodilka.Units;

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

	public Player(string playerName, Point currentPosition, int maxXPos, int maxYPos)
		: base(currentPosition, maxXPos, maxYPos)
	{
		PreviousPosition = currentPosition;
		PlayerName = playerName;
		Simbol = 'P';
		Health = StartHealth;
		Damage = MaxDamage;
		ItemColor = ConsoleColor.Blue;
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
