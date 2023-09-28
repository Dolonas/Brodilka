namespace Brodilka;

public class GameInfo
{
	private string _gameInfoString = string.Empty;
	public Point GameInfoPosition { get; set; }

	public string GameInfoString
	{
		get => _gameInfoString;
		set
		{
			if (value.Length > 20)
				_gameInfoString = value.Remove(20, value.Length);
		}
	}

	public GameInfo(Point point, string gameInfoString)
	{
		GameInfoPosition = point;
		GameInfoString = gameInfoString;
	}
}
