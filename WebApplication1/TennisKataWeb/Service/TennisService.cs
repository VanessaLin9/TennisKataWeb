using WebApplication1.Models;

namespace WebApplication1.Service;

public class TennisService
{
    private readonly string _firstPlayerName;
    private readonly string _secondPlayerName;
    private int _firstPlayerScore;
    private int _secondPlayerScore;

    private readonly Dictionary<int, string> _scoreLookUp = new()
    {
        { 0, "Love" },
        { 1, "Fifteen" },
        { 2, "Thirty" },
        { 3, "Forty" }
    };

    public TennisService(PlayerList playerList)
    {
        _firstPlayerName = playerList.FirstPlayer;
        _secondPlayerName = playerList.SecondPlayer;
    }

    public string GetScore()
    {
        return IsScoreDifferent() 
            ? IsReadyForGamePoint() ? AdvState() : LookUpScore() 
            : IsDeuce() ? Deuce() : SameScore();
    }

    private string AdvState()
    {
        return IsAdv() ? $"{AdvPlayer()} Adv" : $"{AdvPlayer()} Win";
    }

    private static string Deuce()
    {
        return "Deuce";
    }

    private string SameScore()
    {
        return $"{_scoreLookUp[_firstPlayerScore]} All";
    }

    private bool IsDeuce()
    {
        return _firstPlayerScore >=3;
    }

    private string LookUpScore()
    {
        return $"{_scoreLookUp[_firstPlayerScore]} {_scoreLookUp[_secondPlayerScore]}";
    }

    private bool IsAdv()
    {
        return Math.Abs(_firstPlayerScore - _secondPlayerScore) == 1;
    }

    private bool IsReadyForGamePoint()
    {
        return _firstPlayerScore>3 || _secondPlayerScore >3;
    }

    private bool IsScoreDifferent()
    {
        return _firstPlayerScore != _secondPlayerScore;
    }

    private string AdvPlayer()
    {
        var advPlayer = _firstPlayerScore > _secondPlayerScore ? _firstPlayerName : _secondPlayerName;
        return advPlayer;
    }

    public void FirstPlayerScore()
    {
        _firstPlayerScore++;
    }

    public void SecondPlayerScore()
    {
        _secondPlayerScore++;
    }
    
    public string GetFirstPlayerName()
    {
        return _firstPlayerName;
    }
    
    public string GetSecondPlayerName()
    {
        return _secondPlayerName;
    }
    
}