using System.Collections.Generic;

namespace Brodilka.Interfaces;

internal interface IDisplayable
{
	void Display(GameItem gameItem);
	void DisplayGameInfo(List<GameInfo> infoList);
	void DisplayMap(Map map);
	void Redraw();
	void MakeSound(int frequency, int duration);
}
