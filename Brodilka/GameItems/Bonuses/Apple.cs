namespace Brodilka.GameItems.Bonuses;

internal class Apple : Bonus
{
	private readonly int healthUp = 70;
	private readonly int speedUp = 0;

	public Apple(Point point) : base(point)
	{
		Simbol = 'a';
		SpeedUpForPlayer = speedUp;
		HealthUpForPlayer = healthUp;
		IsExist = true;
	}

	public override char Simbol { get; }
}
