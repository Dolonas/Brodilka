namespace Brodilka.GameItems.Units.Enemies;

internal class Wolf : Enemy
{
	private readonly int _wolfDamage = 20;
	private readonly int _wolfMaxHealth = 40;

	public override char Simbol { get; }

	public Wolf(Point currentPosition, int maxXPos, int maxYPos)
		: base(currentPosition, maxXPos, maxYPos)
	{
		Simbol = 'w';
		Damage = _wolfDamage;
		Health = _wolfMaxHealth;
	}
}
