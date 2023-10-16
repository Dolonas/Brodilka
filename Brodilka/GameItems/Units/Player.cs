namespace Brodilka.GameItems.Units;

internal sealed class Player : Unit
{
	private readonly string _name;
	internal Player(string name, Point currentPosition)
		: base(currentPosition)
	{
		PreviousPosition = currentPosition;
		Name = name;
		Simbol = 'P';
		Health = 100;
		Speed = 18;
		Damage = 30;
		ItemDefaultColor = ItemColor.Blue;
	}

	internal override int Damage { get; set; }

	internal string Name
	{
		get => _name;
		init => _name = value.Length is > 1 and < 20 ? value : _name;
	}
}
