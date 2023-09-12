using System.Runtime.Serialization;
using Brodilka.Bonuses;

namespace Brodilka.Obstacles;

public class Tree : Obstacle
{
	public override char Simbol { get; }
	public Tree(Point position, int maxXPos, int maxYPos) : base(position, maxXPos, maxYPos) => Simbol = 't';
}
