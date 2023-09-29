using System;

namespace Brodilka.GameItems.Units;

internal sealed class Player : Unit
{
	private const int MaxDamage = 80;
	private const int StartHealth = 100;
	private readonly string _name;


	public Player(string name, Point currentPosition)
		: base(currentPosition)
	{
		PreviousPosition = currentPosition;
		Name = name;
		Simbol = 'P';
		Health = StartHealth;
		Damage = MaxDamage;
		ItemDefaultColor = ItemColor.Blue;
	}

	internal override int Damage { get; set; }
	public override char Simbol { get; }


	internal string Name
	{
		get => _name;
		init => _name = value.Length is > 1 and < 20 ? value : _name;
	}
}
