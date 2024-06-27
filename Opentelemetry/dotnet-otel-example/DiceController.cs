using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

public class DiceController : ControllerBase
{
    private ILogger<DiceController> logger;
    
    private ActivitySource activitySource;
    public DiceController(ILogger<DiceController> logger,Instrumentation instrumentation)
    {
        this.logger = logger;
        activitySource = instrumentation.ActivitySource;
    }

    [HttpGet("/rolldice")]
    public List<int> RollDice(string player,int? rolls){
        
        List<int> result = new List<int>();


        if(!rolls.HasValue){
            logger.LogError("No rolls specified");
            throw new HttpRequestException("No rolls specified",null,HttpStatusCode.BadRequest);
        }

        result = new Dice(1,6,activitySource).rollTheDice(rolls.Value);

        if (string.IsNullOrEmpty(player))
        {
            logger.LogInformation("Anonymous player is rolling the dice: {result}", result);
        }
        else
        {
            logger.LogInformation("{player} is rolling the dice: {result}", player, result);
        }

        return result;
    }
}