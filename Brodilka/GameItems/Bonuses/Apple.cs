namespace Brodilka.GameItems.Bonuses;

internal class Apple : Bonus
{
	private readonly int speedUp = 0;
	private readonly int healthUp = 70;
	public override char Simbol { get; }

	public Apple(Point currPoint) : base(currPoint)
	{
		Simbol = 'a';
		SpeedUpForPlayer = speedUp;
		HealthUpForPlayer = healthUp;
		IsExist = true;
	}


}
