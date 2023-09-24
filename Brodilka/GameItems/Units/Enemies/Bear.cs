namespace Brodilka.GameItems.Units.Enemies;

internal class Bear : Enemy
{
	private readonly int _bearDamage = 40;
	private readonly int _bearHealth = 70;

	public Bear(Point currentPosition)
		: base(currentPosition)
	{
		Simbol = 'B';
		Damage = _bearDamage;
		Health = _bearHealth;
	}

	public override char Simbol { get; }
}
