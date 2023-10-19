namespace Brodilka.GameItems;

internal abstract class GameItem
{
	private ItemColor _itemDefaultColor = ItemColor.White;
	internal GameItem(Point pos) => Pos = pos;

	internal bool IsExist { get; set; }

	internal ItemColor ItemDefaultColor
	{
		get => _itemDefaultColor;
		set => _itemDefaultColor = ItemColor = value;
	}

	internal ItemColor ItemColor { get; set; }

	internal Point Pos { get; set; }

	internal abstract bool IsItBlock { get; set; }
	internal char Simbol { get; init; }
}
