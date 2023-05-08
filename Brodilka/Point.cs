namespace Brodilka;

internal class Point
{
	private int xPosition;
	private int yPosition;


	public int XPosition
	{
		get => xPosition;
		set => xPosition = value;
	}

	public int YPosition
	{
		get => yPosition;
		set => yPosition = value;
	}

	public Point() : this(0, 0)
	{
	}

	public Point(int xPosition, int yPosition)
	{
		XPosition = xPosition;
		YPosition = yPosition;
	}
}
