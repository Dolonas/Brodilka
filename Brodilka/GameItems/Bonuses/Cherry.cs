namespace Brodilka.GameItems.Bonuses;

internal class Cherry : Bonus
{
	internal Cherry(Point point) : base(point)
	{
		Simbol = 'y';
		SpeedUpForPlayer = 1;
		HealthUpForPlayer = 0;
		IsExist = true;
	}
}
