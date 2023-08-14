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

	public override Command GetCommand()
	{
		var cki = Console.ReadKey();
		if (cki.Key == (ConsoleKey)Command.Escape)
			Environment.Exit(0);
		return cki.Key switch
		{
			ConsoleKey.RightArrow => Command.Right,
			ConsoleKey.LeftArrow => Command.Left,
			ConsoleKey.UpArrow => Command.Up,
			ConsoleKey.DownArrow => Command.Down,
			_ => cki.Key == ConsoleKey.Escape ? Command.Escape : Command.Stop
		};
	}
}
