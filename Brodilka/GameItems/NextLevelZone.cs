namespace Brodilka.GameItems;

internal class NextLevelZone : GameItem
{
	public NextLevelZone(Point position) : base(position)
	{
		Pos = position;
		IsExist = false;
		IsItBlock = false;
		ItemColor = ItemColor.Gray;
		Simbol = 'X';
	}

	internal sealed override bool IsItBlock { get; set; }
}
