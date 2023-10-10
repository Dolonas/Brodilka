namespace Brodilka.GameItems;

public class NextLevelZone : GameItem
{
	public NextLevelZone(Point position) : base(position)
	{
		Pos = position;
		IsExist = false;
		IsItBlock = false;
		ItemColor = ItemColor.Gray;
		Simbol = 'X';
	}

	public override bool IsItBlock { get; set; }
}
