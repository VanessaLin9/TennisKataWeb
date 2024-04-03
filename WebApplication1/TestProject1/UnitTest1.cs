using WebApplication1.Models;
using WebApplication1.Service;
namespace TestProject1;

public class Tests
{
    private TennisService _tennisService;

    [SetUp]
    public void SetUp()
    {
        _tennisService = new TennisService(new PlayerList
        {
            FirstPlayer = "Joey",
            SecondPlayer = "Tom"
        });
    }

    [Test]
    public void Love_All()
    {
        ScoreShouldBe("Love All");
    }
    
    [Test]
    public void Fifteen_Love()
    {
        GivenFirstPlayerScore(1);
        ScoreShouldBe("Fifteen Love");
    }
    
    [Test]
    public void Thirty_Love()
    {
        GivenFirstPlayerScore(2);
        ScoreShouldBe("Thirty Love");
    }

    [Test]
    public void Forty_Love()
    {
        GivenFirstPlayerScore(3);
        ScoreShouldBe("Forty Love");
    }

    [Test]
    public void Love_Fifteen()
    {
        GivenSecondPlayerScore(1);
        ScoreShouldBe("Love Fifteen");
    }
    
    [Test]
    public void Love_Thirty()
    {
        GivenSecondPlayerScore(2);
        ScoreShouldBe("Love Thirty");
    }
    
    
    [Test]
    public void Fifteen_All()
    {
        GivenFirstPlayerScore(1);
        GivenSecondPlayerScore(1);
        ScoreShouldBe("Fifteen All");
    }
    
    [Test]
    public void Thirty_All()
    {
        GivenFirstPlayerScore(2);
        GivenSecondPlayerScore(2);
        ScoreShouldBe("Thirty All");
    }

    
    [Test]
    public void Deuce()
    {
        GivenDeuce();
        ScoreShouldBe("Deuce");
    }
    
    [Test]
    public void FirstPlayer_Adv()
    {
        GivenDeuce();
        GivenFirstPlayerScore(1);
        ScoreShouldBe("Joey Adv");
    }

    [Test]
    public void SecondPlayer_Adv()
    {
        GivenDeuce();
        GivenSecondPlayerScore(1);
        ScoreShouldBe("Tom Adv");
    }

    [Test]
    public void SecondPlayer_Win()
    {
        GivenDeuce();
        GivenSecondPlayerScore(2);
        ScoreShouldBe("Tom Win");
    }

    private void GivenDeuce()
    {
        GivenFirstPlayerScore(3);
        GivenSecondPlayerScore(3);
    }


    private void GivenSecondPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisService.SecondPlayerScore();
        }
    }

    private void GivenFirstPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            _tennisService.FirstPlayerScore();
        }
    }

    private void ScoreShouldBe(string expected)
    {
        Assert.AreEqual(expected, _tennisService.GetScore());
    }
}