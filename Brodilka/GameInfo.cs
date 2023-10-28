namespace Brodilka;

public class GameInfo
{
	private readonly string _gameInfoString = string.Empty;

	public GameInfo(string gameInfoString, ItemColor infoColor)
	{
		GameInfoString = gameInfoString;
		InfoColor = infoColor;
	}

	public ItemColor InfoColor { get; }

	public string GameInfoString
	{
		get => _gameInfoString;
		private init => _gameInfoString = value.Length > 50 ? value.Remove(50, value.Length-50) : value;
	}
}
