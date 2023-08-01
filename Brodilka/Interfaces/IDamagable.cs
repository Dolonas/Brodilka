using Brodilka.Units;

namespace Brodilka.Interfaces;

internal interface IDamagable
{
	void GetDamage(int damage);

	void ToDamage(Unit unit, int hitDamege);
}
