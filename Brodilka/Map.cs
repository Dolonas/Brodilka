namespace Brodilka;

public class Map
{
	private readonly int _xSize;
	private readonly int _ySize;

	public int XSize
	{
		get => _xSize;
		private init => _xSize = value is > 30 and < 160 ? value : 60;
	}

	public int YSize
	{
		get => _ySize;
		private init => _ySize = value is > 30 and < 160 ? value : 60;
	}

	public Map(int xSize, int ySize)
	{
		XSize = xSize;
		YSize = ySize;
	}
}
