namespace Brodilka.GameItems.Obstacles;

public class Stone : Obstacle
{
	public override char Simbol { get; }
	public Stone(Point position, int maxXPos, int maxYPos) : base(position, maxXPos, maxYPos) => Simbol = 'o';
}
