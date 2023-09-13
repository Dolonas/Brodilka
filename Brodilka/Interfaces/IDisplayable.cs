using Brodilka.Units;

namespace Brodilka.Interfaces;

internal interface IDisplayable
{
	void Display(GameItem gameItem);
	void DisplayMap(Map map);
	void Redraw();
	void MakeSound(int frequency, int duration);
}
