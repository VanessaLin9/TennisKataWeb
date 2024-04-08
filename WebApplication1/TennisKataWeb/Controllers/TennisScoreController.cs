using Microsoft.AspNetCore.Mvc;
using WebApplication1.Service;

namespace WebApplication1.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class TennisScoreController(TennisService tennisService) : ControllerBase
{
    
    [HttpGet]
    [Route("GetPlayerList")]
    public string GetTennisPlayerList()
    {
        return tennisService.GetFirstPlayerName() + " vs " + tennisService.GetSecondPlayerName();
    }
    
    [HttpGet]
    [Route("GetScore")]
    public string GetTennisScore()
    {
        return Score();
    }


    [HttpPost]
    [Route("GiveFirstPlayerScore")]
    public string GiveFirstPlayerScore(int score)
    {
        if (IsScoreValidate(score))
        {
            return InvalidScore();
        }
        GivenFirstPlayerScore(score);
        return Score();
    }

    [HttpPost]
    [Route("GiveSecondPlayerScore")]
    public string GiveSecondPlayerScore(int score)
    {
        if (IsScoreValidate(score))
        {
            return InvalidScore();
        }
        GivenSecondPlayerScore(score);
        return Score();
    }

    private static bool IsScoreValidate(int score)
    {
        return score<=0 || score > 7;
    }

    private static string InvalidScore()
    {
        return "Invalid score";
    }

    private string Score()
    {
        return tennisService.GetScore();
    }
    
    private void GivenSecondPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            tennisService.SecondPlayerScore();
        }
    }
    
    private void GivenFirstPlayerScore(int times)
    {
        for (int i = 0; i < times; i++)
        {
            tennisService.FirstPlayerScore();    
        }
    }
}