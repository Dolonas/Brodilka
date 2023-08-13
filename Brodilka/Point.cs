namespace Brodilka;

public class Point
{
	public int XPosition { get; private set; }

	public int YPosition { get; private set; }

	public Point(int xPosition, int yPosition)
	{
		XPosition = xPosition;
		YPosition = yPosition;
	}

}
