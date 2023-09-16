namespace Brodilka.GameItems.Obstacles;

public class Tree : Obstacle
{
	public override char Simbol { get; }
	public Tree(Point position) : base(position) => Simbol = 't';
}
