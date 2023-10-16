namespace Brodilka.GameItems.Bonuses;

internal class Apple : Bonus
{
	internal Apple(Point point) : base(point)
	{
		Simbol = 'a';
		SpeedUpForPlayer = 0;
		HealthUpForPlayer = 70;
		IsExist = true;
	}
}
