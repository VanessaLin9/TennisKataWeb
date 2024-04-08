namespace WebApplication1.Models;

public class PlayerList
{
    public string FirstPlayer { get; set; }
    public string SecondPlayer { get; set; }

    public override string ToString()
    {
        return $"{nameof(FirstPlayer)}: {FirstPlayer}, {nameof(SecondPlayer)}: {SecondPlayer}";
    }
}