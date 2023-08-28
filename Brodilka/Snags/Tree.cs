using System.Runtime.Serialization;
using Brodilka.Bonuses;

namespace Brodilka.Snags;

public class Tree : Snag
{
	public override char Simbol { get; }
	public Tree(Point position, int maxXPos, int maxYPos) : base(position, maxXPos, maxYPos) => Simbol = 't';
}
