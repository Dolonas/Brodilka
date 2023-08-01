namespace Brodilka.Units.Enemies;

internal class Wolf : Enemy
{
	public Wolf() : this(new Point(0, 0), new Map())
	{
	}

	public Wolf(Point currPosition, Map currMap) : base(currPosition, currMap)
	{
		Damage = 20;
		Health = 40;
		IsItBlock = false;
	}
}
