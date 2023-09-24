namespace Brodilka.GameItems.Obstacles;

public class Stone : Obstacle
{
	public Stone(Point position) : base(position) => Simbol = 'o';
	public override char Simbol { get; }
}
