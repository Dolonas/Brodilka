namespace Brodilka.GameItems.Obstacles;

public class Stone : Obstacle
{
	public override char Simbol { get; }
	public Stone(Point position) : base(position) => Simbol = 'o';
}
