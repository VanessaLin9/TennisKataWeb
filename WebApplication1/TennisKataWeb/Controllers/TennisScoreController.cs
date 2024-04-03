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
        GivenFirstPlayerScore(score);
        return Score();
    }

    


    [HttpPost]
    [Route("GiveSecondPlayerScore")]
    public string GiveSecondPlayerScore()
    {
        tennisService.SecondPlayerScore();
        return Score();
    }

    private string Score()
    {
        return tennisService.GetScore();
    }
    
    private void GivenFirstPlayerScore(int score)
    {
        for (int i = 0; i < score; i++)
        {
            tennisService.FirstPlayerScore();    
        }
    }
}