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
		private init => _gameInfoString = value.Length > 20 ? value.Remove(20, value.Length) : value;
	}
}
