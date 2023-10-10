namespace Brodilka.GameItems.Units;

internal sealed class Player : Unit
{
	private const int MaxDamage = 30;
	private const int StartHealth = 100;
	private const int NormalSpeed = 18;
	private readonly string _name;


	public Player(string name, Point currentPosition)
		: base(currentPosition)
	{
		PreviousPosition = currentPosition;
		Name = name;
		Simbol = 'P';
		Health = StartHealth;
		Speed = NormalSpeed;
		Damage = MaxDamage;
		ItemDefaultColor = ItemColor.Blue;
	}

	internal override int Damage { get; set; }
	//public char Simbol { get; }


	internal string Name
	{
		get => _name;
		init => _name = value.Length is > 1 and < 20 ? value : _name;
	}
}
