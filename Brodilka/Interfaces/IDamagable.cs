using Brodilka.GameItems.Units;

namespace Brodilka.Interfaces;

internal interface IDamagable
{
	void GetDamage(int damage);

	void ToDamage(Unit unit, int damage);
}
