namespace Brodilka.GameItems.Bonuses;

internal class Apple : Bonus
{
	private readonly int speedUp = 0;
	private readonly int healthUp = 70;
	public override char Simbol { get; }

	public Apple(Point currentPoint) : base(currentPoint)
	{
		Simbol = 'a';
		SpeedUpForPlayer = speedUp;
		HealthUpForPlayer = healthUp;
		IsExist = true;
	}


}
