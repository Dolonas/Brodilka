namespace Brodilka.GameItems.Units.Enemies;

internal class Bear : Enemy
{
	private const int BearDamage = 2;
	private const int BearHealth = 70;
	private const int NormalSpeed = 15;

	public Bear(Point currentPosition)
		: base(currentPosition)
	{
		Simbol = 'B';
		Damage = BearDamage;
		Health = BearHealth;
		Speed = NormalSpeed;
	}

	public override char Simbol { get; }
}
