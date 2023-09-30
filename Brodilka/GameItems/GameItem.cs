namespace Brodilka.GameItems;

public abstract class GameItem
{
	private ItemColor _itemDefaultColor = ItemColor.White;
	public GameItem(Point pos) => Pos = pos;

	public bool IsExist { get; set; }

	protected ItemColor ItemDefaultColor
	{
		get => _itemDefaultColor;
		set => _itemDefaultColor = ItemColor = value;
	}

	public ItemColor ItemColor { get; protected set; }

	public Point Pos { get; set; }

	public abstract bool IsItBlock { get; set; }
	public abstract char Simbol { get; }
}
