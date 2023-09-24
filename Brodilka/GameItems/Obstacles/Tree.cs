namespace Brodilka.GameItems.Obstacles;

public class Tree : Obstacle
{
	public Tree(Point position) : base(position) => Simbol = 't';
	public override char Simbol { get; }
}
