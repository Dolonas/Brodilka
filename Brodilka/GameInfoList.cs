using System.Collections.Generic;

namespace Brodilka;

public class GameInfoList
{
	public List<GameInfo> List { get; set; }
	public int InfoLinePosition { get; set; }
	public int StartXPosition { get; set; }

	public GameInfoList(int infoLinePosition, int startXPosition)
	{
		InfoLinePosition = infoLinePosition;
		StartXPosition = startXPosition;
		List = new List<GameInfo>();
	}

	public void Add(GameInfo gameInfo)
	{
		List.Add(gameInfo);
	}
}
