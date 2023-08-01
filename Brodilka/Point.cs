namespace Brodilka;

internal class Point
{
	public int XPosition { get; set; }

	public int YPosition { get; set; }

	public Point() : this(0, 0)
	{
	}

	public Point(int xPosition, int yPosition)
	{
		XPosition = xPosition;
		YPosition = yPosition;
	}
}
