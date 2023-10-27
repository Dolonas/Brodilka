using System.Collections.Generic;
using Brodilka.GameItems;

namespace Brodilka.Interfaces;

internal interface IDisplayable
{
	void Display(GameItem gameItem);
	void DisplayGameInfo(List<GameInfoDict> infoDict);
	void DisplayMap(Map map);
	void Redraw();
	void MakeSound(int frequency, int duration);
	void ShowGameOverScreen();
	void GoToWinScreen();
}
