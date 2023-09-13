using System;

namespace Brodilka.GameItems.Units;

internal class Player : Unit
{
	private const int MaxDamage = 80;
	private readonly string _playerName;
	private const int StartHealth = 100;
	internal sealed override int Damage { get; set; }
	public override char Simbol { get; }
	public sealed override Point PreviousPosition { get; set; }

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

}
