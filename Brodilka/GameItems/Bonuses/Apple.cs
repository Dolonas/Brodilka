namespace Brodilka.GameItems.Bonuses;

internal class Apple : Bonus
{
	private readonly int _healthUp = 70;
	private readonly int _speedUp = 0;

	public Apple(Point point) : base(point)
	{
		Simbol = 'a';
		SpeedUpForPlayer = _speedUp;
		HealthUpForPlayer = _healthUp;
		IsExist = true;
	}
}
