namespace Brodilka.Snags;

public class Stone : Snag
{
	public override char Simbol { get; }
	public Stone(Point position, int maxXPos, int maxYPos) : base(position, maxXPos, maxYPos) => Simbol = 'o';
}
