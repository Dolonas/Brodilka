using System.Runtime.Serialization;
using Brodilka.Bonuses;

namespace Brodilka.Units.Enemies;

[KnownType(typeof(Wolf))]
internal class Wolf : Enemy
{
	private readonly int _wolfDamage = 20;
	private readonly int _wolfMaxHealth = 40;

	public override char Simbol { get; }

	public Wolf(Point currentPosition, int maxXPosition, int maxYPosition)
		: base(currentPosition, maxXPosition, maxYPosition)
	{
		Simbol = 'w';
		Damage = _wolfDamage;
		Health = _wolfMaxHealth;
	}
}
