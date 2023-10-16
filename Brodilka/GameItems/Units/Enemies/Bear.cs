namespace Brodilka.GameItems.Units.Enemies;

internal class Bear : Enemy
{
	public Bear(Point currentPosition)
		: base(currentPosition)
	{
		Simbol = 'B';
		Damage = 2;
		Health = 70;
		Speed = 15;
	}
}
