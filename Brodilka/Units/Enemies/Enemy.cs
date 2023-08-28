using System;
namespace Brodilka.Units.Enemies;

internal class Enemy : Unit
{
	internal override int Damage { get; set; }
	public override char Simbol { get; }

	public override Point PreviousPosition { get; set; }

	public Enemy(Point currentPosition, int maxXPos, int maxYPos)
		: base(currentPosition, maxXPos, maxYPos)
	{
		IsItBlock = true;
		IsExist = true;
		ItemColor = ConsoleColor.Green;
	}
	public void Move()
	{
		var command = GetKeyboardReceive();
		PreviousPosition = new Point(CurrentPos.XPos, CurrentPos.YPos);
		switch (command)
		{
			case Command.Left:
				CurrentPos = new Point(CurrentPos.XPos - 1, CurrentPos.YPos);
				break;
			case Command.Right:
				CurrentPos = new Point(CurrentPos.XPos + 1, CurrentPos.YPos);
				break;
			case Command.Up:
				CurrentPos = new Point(CurrentPos.XPos, CurrentPos.YPos-1);
				break;
			case Command.Down:
				CurrentPos = new Point(CurrentPos.XPos, CurrentPos.YPos+1);
				break;
			default:
				CurrentPos = new Point(CurrentPos.XPos, CurrentPos.YPos);
				break;
		}
	}
	public Command GetKeyboardReceive()
	{
		var rnd = new Random();
		var seed = rnd.Next(4);
		switch (seed + 1)
		{
			case 1:
				return Command.Left;
			case 2:
				return Command.Right;
			case 3:
				return Command.Up;
			case 4:
				return Command.Down;
		}

		return Command.Non;
	}
}
