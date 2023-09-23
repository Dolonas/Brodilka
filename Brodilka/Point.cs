namespace Brodilka;

public class Point
{
	public int XPos { get; set; }

	public int YPos { get; private set; }

	public Point(int xPos, int yPos)
	{
		XPos = xPos;
		YPos = yPos;
	}

}
