namespace Brodilka;

internal class Player : Unit
{
    private int damage;
    private readonly int maxDamage = 80;
    private string playerName;
    private readonly int startHealth = 100;
    private readonly int signCode = 64;
    internal override int Damage { get => damage; set => damage = value; }
    internal string PlayerName
    {
        get => playerName;
        set => playerName = value.Length is > 1 and < 20 ?  value : playerName;
    }

    public Player() : this (new Point(0, 0), new Map(), "Player 1")
    {
    }

    public Player(Point currentPosition, Map currMap, string playerName): base (currentPosition, currMap)
    {
        PlayerName = playerName;
        Health = this.startHealth;
        SignCode = signCode;
        Damage = maxDamage;
    }

    public void Move(Command command)
    {
        switch (command)
        {
            case Command.Right:
                this.CurrentPosition.XPosition++;
                break;
            case Command.Left:
                this.CurrentPosition.XPosition--;
                break;
            case Command.Up:
                this.CurrentPosition.YPosition--;
                break;
            case Command.Down :
                this.CurrentPosition.YPosition++;
                break;
        }
    }
}
