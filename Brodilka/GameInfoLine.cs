using System.Collections.Generic;

namespace Brodilka;

public class GameInfoLine
{
	public GameInfoLine(int infoLineYPosition, int startXPosition)
	{
		InfoLineYPosition = infoLineYPosition;
		StartXPosition = startXPosition;
		InfoDict = new Dictionary<string, GameInfo>();
	}

	public Dictionary<string, GameInfo> InfoDict { get; set; }
	public int InfoLineYPosition { get; set; }
	public int StartXPosition { get; set; }

	public void Add(string infoName, GameInfo gameInfo)
	{
		InfoDict.Add(infoName, gameInfo);
	}
}
