namespace Brodilka.GameItems.Bonuses;

internal class Cherry : Bonus
{
	private readonly int _healthUp = 0;
	private readonly int _speedUp = 5;

	public Cherry(Point currPoint) : base(currPoint)
	{
		Simbol = 'y';
		SpeedUpForPlayer = _speedUp;
		HealthUpForPlayer = _healthUp;
		IsExist = true;
	}

	public override char Simbol { get; }
}
